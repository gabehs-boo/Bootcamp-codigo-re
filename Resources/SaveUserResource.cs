using System.ComponentModel.DataAnnotations;

namespace Users.API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
    }
}