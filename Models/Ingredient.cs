using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models
{
    public class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}
