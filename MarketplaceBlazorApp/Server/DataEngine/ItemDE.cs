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
        public static IEnumerable<ItemModel> GetItems(int itemID = 0)
        {
            return GetItemWithPhotos(itemID);
        }

        public static List<ItemModel> GetItemWithPhotos(int itemID = 0) //TO DO : make better
        {
            var param = new { ItemID = itemID };
            using (SqlConnection cnn = new SqlConnection(DapperORM.GetConnectionString()))
            {
                string sql = "ItemGET";
                List<ItemModel> listItems = null;
                var lists = cnn.Query<ItemModel, ItemPhotoModel, ItemModel>(sql, (i, p) =>
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
    }
}
