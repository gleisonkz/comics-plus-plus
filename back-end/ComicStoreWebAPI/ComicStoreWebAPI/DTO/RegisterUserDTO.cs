using System.ComponentModel.DataAnnotations;

namespace ComicStore.Application.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string PasswordCheck { get; set; }
    }
}
