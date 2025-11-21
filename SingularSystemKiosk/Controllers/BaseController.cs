
namespace SingularSystemKiosk.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SingularSystemKiosk.Data;
    using SingularSystemKiosk.Models;

    public class BaseController : ControllerBase// Classes are in pascal
    {
        protected readonly AppDbContext _appDbContext; //prtected is camelCase
        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly RoleManager<IdentityRole> _roleManager;

        public BaseController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)// spaces after each comma
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

    }
}
