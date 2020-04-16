using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.DataEngine
{
    public class PhoneDE
    {
        public async Task<IEnumerable<PhoneModel>> GetPhonesByUserID(int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", userID);
            return await DapperORM.ReturListAsync<PhoneModel>("PhoneGET", param);
        }

        public async Task AddOrEditPhone(PhoneModel phoneModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Number", phoneModel.Number);
            param.Add("@UserID", phoneModel.UserID);

            if (phoneModel.PhoneID == 0)
            {
                await DapperORM.ExecuteWithoutReturnAsync("PhoneSET", param);
            }
            else
            {
                param.Add("@PhoneID", phoneModel.PhoneID);
                await DapperORM.ExecuteWithoutReturnAsync("PhoneUPDATE", param);
            }
        }

        public async Task DeletePhone(int phoneID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PhoneID", phoneID);
            await DapperORM.ExecuteWithoutReturnAsync("PhoneDELETE", param);
        }
    }
}
