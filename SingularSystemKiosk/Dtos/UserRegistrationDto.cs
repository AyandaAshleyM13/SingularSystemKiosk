using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SingularSystemKiosk.Models;

namespace SingularSystemKiosk.Dtos
{
    public class UserRegistrationDto
    {

        [Required(ErrorMessage = "Name is required")]
    
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email must be at least {2} characters long.", MinimumLength = 3)]
        public string Email { get; set; }




        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RepeatPassword { get; set; } 
       
        
     





    }
}
