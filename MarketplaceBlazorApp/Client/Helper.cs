using Microsoft.AspNetCore.Hosting;

namespace MarketplaceBlazorApp.Client
{
    public class Helper
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Helper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetPath()
        {
            return _hostingEnvironment.ContentRootPath;
        }
    }
}
