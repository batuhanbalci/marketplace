using System.ComponentModel.DataAnnotations;

namespace MarketplaceBlazorApp.Shared
{
    public class AuthenticateModel
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
