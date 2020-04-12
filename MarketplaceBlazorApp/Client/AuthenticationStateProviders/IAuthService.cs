using System.Threading.Tasks;

namespace MarketplaceBlazorApp.Client.AuthenticationStateProviders
{
    public interface IAuthService
    {
        Task<UserModel> Login(AuthenticateModel loginModel);
        Task Logout();
        Task<RegisterResultModel> Register(UserModel registerModel);
    }
}
