using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SingularSystemKiosk.Data;
using SingularSystemKiosk.Dtos;
using SingularSystemKiosk.Models;

namespace SingularSystemKiosk.Controllers
{
    public class UserController : BaseController
    {
        public UserController(
       AppDbContext appDbContext,
       UserManager<AppUser> userManager,
       SignInManager<AppUser> signInManager,
       RoleManager<IdentityRole> roleManager)
       : base(appDbContext, userManager, signInManager, roleManager)
        {
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (appUser == null || !await _userManager.CheckPasswordAsync(appUser, loginDTO.Password))
                return Unauthorized("Invalid credentials");

            return Ok(new { Message = "Logged in Successfully" });
        }
        [HttpPost, Route("Register")]
        public async Task<IActionResult> Registration(UserRegistrationDto registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existinguser = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (existinguser!=null)
            {
                    return BadRequest("This email already exists");
            }


            else 
            {



                if (registerDTO.Password != registerDTO.RepeatPassword)
                {



                    return BadRequest("Your Password and Repeat Password are not matching!");

                }

                    var appUser = new AppUser
                    {

                        Email = registerDTO.Email,
                        Name = registerDTO.Name,
                        CreatedAt = DateTime.UtcNow, 
                        UserName=registerDTO.Email

                    };
                    var result = await _userManager.CreateAsync(appUser, registerDTO.Password);


                    if (result.Succeeded) {



                    await _userManager.AddToRoleAsync(appUser, "Customer");
                    return Ok("You have successfully registered");
                    
                    }



                return Ok(result);

            
            
            }




               
        }





    }
}
