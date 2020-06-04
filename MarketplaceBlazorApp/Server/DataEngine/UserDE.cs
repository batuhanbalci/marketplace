using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.DataEngine
{
    public class UserDE
    {
        public UserModel UserLogin(UserModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Mail", user.Mail);
            param.Add("@Password", user.Password);

            var result = DapperORM.ReturList<UserModel>("UserLOGIN", param);
            if (result.Count<UserModel>() == 0)
            {
                return null;
            }
            return result.First<UserModel>();
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int userID = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", userID);
            return await DapperORM.ReturListAsync<UserModel>("UserGET", param);
        }

        public async Task AddOrEdit(UserModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Mail", user.Mail);
            param.Add("@Password", user.Password);
            param.Add("@Name", user.Name);
            param.Add("@Surname", user.Surname);
            param.Add("@Role", user.Role);
            param.Add("@TCKNO", user.Tckno);

            if (user.UserID > 0)
            {
                param.Add("@UserID", user.UserID);
                await DapperORM.ExecuteWithoutReturnAsync("UserUPDATE", param);
            }
            else
            {
                await DapperORM.ExecuteWithoutReturnAsync("UserSET", param);
            }
        }

        public async Task DeleteUser(int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", userID);
            await DapperORM.ExecuteWithoutReturnAsync("UserDELETE", param);
        }
    }
}
