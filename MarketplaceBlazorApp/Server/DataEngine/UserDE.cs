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
        public LoginResultModel UserLogin(AuthenticateModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Mail", user.Mail);
            param.Add("@Password", user.Password);

            var result = DapperORM.ReturList<LoginResultModel>("UserLOGIN", param);
            if (result.Count<LoginResultModel>() == 0)
            {
                return null;
            }
            return result.First<LoginResultModel>();
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int userID = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", userID);
            return await DapperORM.ReturListAsync<UserModel>("UserGET", param);
        }

        public async Task AddUser(UserRegisterModel user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Mail", user.Mail);
            param.Add("@Password", user.Password);
            param.Add("@Name", user.Name);
            param.Add("@Surname", user.Surname);
            param.Add("@Role", user.Role);
            param.Add("@TCKNO", user.Tckno);

            await DapperORM.ExecuteWithoutReturnAsync("UserSET", param);
        }

        public async Task EditUser(UserModel user)
        {         
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", user.UserID);
            param.Add("@Mail", user.Mail);
            param.Add("@Password", user.Password);
            param.Add("@Name", user.Name);
            param.Add("@Surname", user.Surname);
            param.Add("@Role", user.Role);
            param.Add("@TCKNO", user.Tckno);

            await DapperORM.ExecuteWithoutReturnAsync("UserUPDATE", param);
        }

        public async Task DeleteUser(int userID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", userID);
            await DapperORM.ExecuteWithoutReturnAsync("UserDELETE", param);
        }
    }
}
