using Microsoft.AspNetCore.Identity;

namespace SingularSystemKiosk.Models
{
    public class AppUser:IdentityUser
    {

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
