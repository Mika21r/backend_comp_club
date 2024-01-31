using System.ComponentModel.DataAnnotations;

namespace kursovayK.Models.Dtos
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } 
      
    }
}
