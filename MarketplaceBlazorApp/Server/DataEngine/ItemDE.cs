using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.DataEngine
{
    public class ItemDE
    {
        public async Task<IEnumerable<ItemModel>> GetItems(int itemID = 0)
        {
            return await GetItemWithPhotos(itemID);
        }

        public async Task<List<ItemModel>> GetItemWithPhotos(int itemID = 0, int userID = 0) //TO DO : make better
        {
            DynamicParameters param = new DynamicParameters();
            string sql;
            if (userID > 0)
            {
                param.Add("@UserID", userID);
                sql = "ItemGETByUserID";
            }
            else
            {
                param.Add("@ItemID", itemID);
                sql = "ItemGET";
            }

            using (SqlConnection cnn = new SqlConnection(DapperORM.GetConnectionString()))
            {
                List<ItemModel> listItems = null;
                var lists = await cnn.QueryAsync<ItemModel, ItemPhotoModel, ItemModel>(sql, (i, p) =>
                {
                    i.ItemPhotos = new List<ItemPhotoModel>();
                    i.ItemPhotos.Add(p);
                    return i;
                }, param, commandType: CommandType.StoredProcedure, splitOn: "PhotoID");
                var result = lists.GroupBy(item => item.ItemID).Select(g =>
                {
                    var groupedPost = g.First();
                    groupedPost.ItemPhotos = g.Select(p => p.ItemPhotos.Single()).ToList();
                    return groupedPost;
                });
                listItems = result.ToList<ItemModel>();
                return listItems;
            }
        }

        //public async Task<List<ItemModel>> GetItemWithPhotos(int itemID = 0, int userID = 0) //DENEME
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    string sql;
        //    if (userID > 0)
        //    {
        //        param.Add("@UserID", userID);
        //        sql = "ItemGETByUserID";
        //    }
        //    else
        //    {
        //        param.Add("@ItemID", itemID);
        //        sql = "ItemGETTESTDELETE";
        //    }

        //    using (SqlConnection cnn = new SqlConnection(DapperORM.GetConnectionString()))
        //    {
        //        List<ItemModel> listItems = null;
        //        var lists = await cnn.QueryAsync<ItemModel, ItemPhotoModel, PropertyModel, ItemModel>(sql, (i, p, prop) =>
        //        {
        //            i.ItemPhotos = new List<ItemPhotoModel>();
        //            i.ItemPhotos.Add(p);
        //            i.Properties = new List<PropertyModel>();
        //            i.Properties.Add(prop);
        //            return i;
        //        }, param, commandType: CommandType.StoredProcedure, splitOn: "PhotoID,Path,PropertyID");

        //        var result = lists.GroupBy(item => item.ItemID).Select(g =>
        //        {
        //            var groupedPost = g.First();
        //            groupedPost.Properties = g.Select(p => p.Properties.Single()).ToList();
        //            groupedPost.ItemPhotos = g.Select(p => p.ItemPhotos.Single()).ToList();
        //            return groupedPost;
        //        });

        //        listItems = result.ToList<ItemModel>();
        //        return listItems;
        //    }
        //}

        //public async Task<IEnumerable<ItemModel>> GetItemWithPhotos(int itemID = 0, int userID = 0) //DENEME
        //{
        //    string sql;
        //    //param.Add("@ItemID", itemID);
        //    sql = "DECLARE @ItemID int = "+ itemID + " DECLARE @CatID int = (SELECT CategoryID FROM Items WHERE Items.ItemID = @ItemID) ;WITH tblParent AS (SELECT * FROM Categories WHERE CategoryID = @CatID UNION ALL SELECT Categories.* FROM Categories JOIN tblParent ON Categories.CategoryID = tblParent.ParentCategoryID ) SELECT Items.ItemID, Title, Description, Items.CategoryID, UserID, Price, State, ReleaseDate, ClickCount, NeighborhoodID, MapX, MapY, ProfilePhotoPath, ItemPhotos.PhotoID, ItemPhotos.Path, Properties.PropertyID, Properties.PropertyName, Properties.Type, PropertyValues.Value FROM Items LEFT JOIN ItemPhotos ON Items.ItemID = ItemPhotos.ItemID LEFT JOIN Properties ON Items.CategoryID IN(SELECT CategoryID FROM tblParent WHERE Properties.CategoryID<> @CatID) OR Properties.CategoryID = @CatID LEFT JOIN PropertyValues ON Items.ItemID = PropertyValues.ItemID AND Properties.PropertyID = PropertyValues.PropertyID WHERE(Items.ItemID = @ItemID)";


        //    using (SqlConnection cnn = new SqlConnection(DapperORM.GetConnectionString()))
        //    {
        //        var itemDict = new Dictionary<int, ItemModel>();

        //        var list = cnn.Query<ItemModel, ItemPhotoModel, PropertyModel, ItemModel>(
        //            sql,
        //            (item, itemPhoto, itemProp) =>
        //            {
        //                ItemModel itemEntry;

        //                if (!itemDict.TryGetValue(item.ItemID, out itemEntry))
        //                {
        //                    itemEntry = item;
        //                    itemEntry.ItemPhotos = new List<ItemPhotoModel>();
        //                    itemEntry.Properties = new List<PropertyModel>();
        //                    itemDict.Add(itemEntry.ItemID, itemEntry);
        //                }

        //                itemEntry.ItemPhotos.Add(itemPhoto);
        //                itemEntry.Properties.Add(itemProp);
        //                return itemEntry;
        //            },
        //            splitOn: "PhotoID,PropertyID")
        //        .Distinct()
        //        .ToList();

        //        return list;
        //    }
        //}

        public async Task MakeProfilePhoto(int itemID, string photoPath)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ItemID", itemID);
            param.Add("@PhotoPath", photoPath);
            await DapperORM.ExecuteWithoutReturnAsync("ItemProfilePhotoSET", param);
        }

        public async Task AddOrEditItem(ItemModel item)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", item.Title);
            param.Add("@Description", item.Description);
            param.Add("@CategoryID", item.CategoryID);
            param.Add("@UserID", item.UserID);
            param.Add("@Price", item.Price);
            param.Add("@State", item.State);
            param.Add("@NeighborhoodID", item.NeighborhoodID);
            param.Add("@MapX", item.MapX);
            param.Add("@MapY", item.MapY);
            param.Add("@ProfilePhotoPath", item.ProfilePhotoPath);
            param.Add("@ReleaseDate", item.ReleaseDate);

            if (item.ItemID == 0)
            {
                await DapperORM.ExecuteWithoutReturnAsync("ItemSET", param);
            }
            else
            {
                param.Add("@ItemID", item.ItemID);
                await DapperORM.ExecuteWithoutReturnAsync("ItemUPDATE", param);
            }
        }

        public async Task IncreaseClickCount(int itemID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ItemID", itemID);
            await DapperORM.ExecuteWithoutReturnAsync("ItemClickCountSET", param);
        }
    }
}
