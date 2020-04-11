using System.ComponentModel.DataAnnotations;

namespace MarketplaceBlazorApp
{
    public class UserModel
    {
        private int userID;
        private string mail;
        private string password;
        private string name;
        private string surname;
        private Roles role;
        private string tckno;
        private string token;

        public int UserID { get => userID; set => userID = value; }

        [Required]
        [EmailAddress]
        public string Mail { get => mail; set => mail = value; }

        public string Password { get => password; set => password = value; }

        [Required]
        public string Name { get => name; set => name = value; }

        [Required]
        public string Surname { get => surname; set => surname = value; }

        [Required]
        public Roles Role { get => role; set => role = value; }

        [Display(Name = "TC Kimlik No")]
        [StringLength(11, ErrorMessage = "TC Kimlik No 11 haneli olmalıdır.", MinimumLength = 11)]
        [RegularExpression(@"^[0-9]*$")]
        public string Tckno { get => tckno; set => tckno = value; }
        public string Token { get => token; set => token = value; }
    }
}
