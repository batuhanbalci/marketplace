using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceBlazorApp.Shared
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
        private string confirmPassword;
        private bool successful;
        private string error;
        public int UserID { get => userID; set => userID = value; }

        [Required]
        [EmailAddress]
        public string Mail { get => mail; set => mail = value; }

        [Required]
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

        [Required]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public bool Successful { get => successful; set => successful = value; }
        public string Error { get => error; set => error = value; }
    }

    public class UserRegisterModel
    {
        private string mail;
        private string password;
        private string name;
        private string surname;
        private Roles role;
        private string tckno;
        private string token;
        private string confirmPassword;
        private bool successful;
        private string error;

        [Required]
        [EmailAddress]
        public string Mail { get => mail; set => mail = value; }

        [Required]
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

        [Required]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public bool Successful { get => successful; set => successful = value; }
        public string Error { get => error; set => error = value; }
    }

    public class LoginResultModel
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public int UserID { get; set; }
        public Roles Role { get; set; }
}

    public class RegisterResultModel
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
