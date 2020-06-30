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
                var lists = await cnn.QueryAsync<ItemModel, UserModel, ItemPhotoModel, ItemModel>(sql, (i, u, p) =>
                {
                    i.ItemPhotos = new List<ItemPhotoModel>();
                    i.ItemPhotos.Add(p);
                    i.User = new UserModel();
                    i.User = u;
                    return i;
                }, param, commandType: CommandType.StoredProcedure, splitOn: "UserID, PhotoID");
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
            param.Add("@UserID", item.User.UserID);
            param.Add("@Price", item.Price);
            param.Add("@State", item.State);
            param.Add("@NeighborhoodID", item.NeighborhoodID);
            param.Add("@MapX", item.MapX);
            param.Add("@MapY", item.MapY);
            param.Add("@ProfilePhotoPath", item.ProfilePhotoPath);

            if (item.ItemID == 0)
            {
                item.ItemID = DapperORM.ExecuteReturnScalar<int>("ItemSET", param);
                if (item.Properties != null)
                {
                    foreach (var property in item.Properties)
                    {
                        DynamicParameters propparam = new DynamicParameters();
                        propparam.Add("@PropertyID", property.PropertyID);
                        propparam.Add("@Value", property.Value);
                        propparam.Add("@ItemID", item.ItemID);
                        DapperORM.ExecuteWithoutReturn("ItemPropertyValueSET", propparam);
                    }
                }
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

        public async Task ItemDelete(int itemID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ItemID", itemID);
            await DapperORM.ExecuteWithoutReturnAsync("ItemDELETE", param);
        }
    }
}
