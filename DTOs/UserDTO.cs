using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
