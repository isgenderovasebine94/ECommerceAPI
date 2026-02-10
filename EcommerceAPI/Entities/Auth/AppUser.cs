using Microsoft.AspNetCore.Identity;

namespace EcommerceAPI.Entities.Auth
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
