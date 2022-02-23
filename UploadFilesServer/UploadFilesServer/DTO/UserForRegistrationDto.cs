using System.ComponentModel.DataAnnotations;

namespace UploadFilesServer.DTO
{
    public class UserForRegistrationDto
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
