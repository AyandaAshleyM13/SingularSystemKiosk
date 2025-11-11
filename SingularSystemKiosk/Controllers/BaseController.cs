using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SingularSystemKiosk.Data;
using SingularSystemKiosk.Models;

namespace SingularSystemKiosk.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly RoleManager<IdentityRole> _roleManager;

        public BaseController(
            AppDbContext appDbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

    }
}
