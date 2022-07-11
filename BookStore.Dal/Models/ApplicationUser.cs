using Microsoft.AspNetCore.Identity;

namespace bookStore.Dal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Test { get; set; }
    }
}
