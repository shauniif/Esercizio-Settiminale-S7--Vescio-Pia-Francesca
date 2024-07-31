using System.ComponentModel.DataAnnotations;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models
{
    public class UserViewModel
    {
        
        [Required(ErrorMessage ="Il nome è obbligatorio")]
        [StringLength(30)]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        public List<Role> Roles { get; set; } = [];

        public List<Order> Orders { get; set; } = [];
    }
}
