using System.ComponentModel.DataAnnotations;

namespace BookStore.Dal.ViewModels
{
    public class RegistrationViewModel

    {
        [Required(ErrorMessage ="email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
    }
}
