using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SingularSystemKiosk.Controllers;
using SingularSystemKiosk.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace SingularSystemKiosk.Data
{
    public class  Seed:BaseController
    {

        public Seed(
          AppDbContext appDbContext,
          UserManager<AppUser> userManager,
          SignInManager<AppUser> signInManager,
          RoleManager<IdentityRole> roleManager)
          : base(appDbContext, userManager, signInManager, roleManager)
        {
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {


            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }





        }

        public static async Task SeedAdmin(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string adminEmail = "Admin@Singular.com";
            string adminPassword = "Secure@123";

            var existingUser = await userManager.FindByEmailAsync(adminEmail);
            if (existingUser == null)
            {
                var appUser = new AppUser
                {
                    UserName = adminEmail,   
                    Email = adminEmail,
                    Name = "System Admin",
                    CreatedAt = DateTime.UtcNow,
                  
                };

                var result = await userManager.CreateAsync(appUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "Admin");
                }
                else
                {
                    throw new Exception("Admin seeding failed: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }






    }
}
