using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MarketplaceBlazorApp.DataEngine
{
    public class ImageDE
    {
        public async Task DeletePhoto(int photoID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PhotoID", photoID);
            await DapperORM.ExecuteWithoutReturnAsync("ItemPhotoDELETE", param);
        }

        public async Task SaveItemPhoto(int itemID = 0, string fileName = "")
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Path", fileName);
            param.Add("@ItemID", itemID);
            await DapperORM.ExecuteWithoutReturnAsync("ItemPhotoSET", param);
        }

        //public async Task<bool> CheckIsPhotoProfilePhoto(string profilePhotoPath)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@Path", profilePhotoPath);
        //    await DapperORM.ExecuteReturnScalarAsync<bool>("", param);
        //}
    }
}
