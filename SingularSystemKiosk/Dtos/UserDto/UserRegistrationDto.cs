

namespace SingularSystemKiosk.Dtos.UserDto
{

    using System.ComponentModel.DataAnnotations;

    public class UserRegistrationDto
    {

        [Required(ErrorMessage = "Name is required")]
    
        public string Name { get; set; }= string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email must be at least {2} characters long.", MinimumLength = 3)]
        public string Email { get; set; }=string.Empty;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RepeatPassword { get; set; } = string.Empty;  
       
        
     





    }
}
