using System.ComponentModel.DataAnnotations;

namespace MarketplaceBlazorApp.Shared
{
    public class AuthenticateModel
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
