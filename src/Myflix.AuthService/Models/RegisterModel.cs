using System.ComponentModel.DataAnnotations;

namespace Myflix.AuthService.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
