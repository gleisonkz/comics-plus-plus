using System.ComponentModel.DataAnnotations;

namespace ComicStore.Application.DTO
{
    public class LoginUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
