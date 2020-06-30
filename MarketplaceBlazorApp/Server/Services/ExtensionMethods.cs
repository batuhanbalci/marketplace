using System.Collections.Generic;
using System.Linq;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.Server.Services
{
    public static class ExtensionMethods
    {
        public static IEnumerable<LoginResultModel> WithoutPasswords(this IEnumerable<LoginResultModel> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static LoginResultModel WithoutPassword(this LoginResultModel user)
        {
            //user.Password = null;
            return user;
        }
    }
}
