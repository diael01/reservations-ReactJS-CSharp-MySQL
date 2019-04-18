using System.ComponentModel.DataAnnotations;

namespace WEBAPI.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password;

        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword;
    }
}