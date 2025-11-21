
namespace SingularSystemKiosk.Models

{
    using Microsoft.AspNetCore.Identity;

    public class AppUser:IdentityUser
    {

        public string Name { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
