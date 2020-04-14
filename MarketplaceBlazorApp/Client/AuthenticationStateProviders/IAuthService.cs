using System.Threading.Tasks;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.Client.AuthenticationStateProviders
{
    public interface IAuthService
    {
        Task<UserModel> Login(AuthenticateModel loginModel);
        Task Logout();
        Task<RegisterResultModel> Register(UserModel registerModel);
    }
}
