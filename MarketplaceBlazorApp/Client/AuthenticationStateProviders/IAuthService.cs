using System.Threading.Tasks;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.Client.AuthenticationStateProviders
{
    public interface IAuthService
    {
        Task<LoginResultModel> Login(AuthenticateModel loginModel);
        Task Logout();
        Task<RegisterResultModel> Register(UserRegisterModel registerModel);
    }
}
