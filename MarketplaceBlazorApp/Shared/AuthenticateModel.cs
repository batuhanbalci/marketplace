using System.ComponentModel.DataAnnotations;

namespace MarketplaceBlazorApp
{
    public class AuthenticateModel
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
