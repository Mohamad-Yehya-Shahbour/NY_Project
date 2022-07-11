using System.ComponentModel.DataAnnotations;

namespace BookStore.Dal.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
