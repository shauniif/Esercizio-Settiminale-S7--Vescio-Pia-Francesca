using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Range(0, 50)]
        [Column(TypeName ="decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required,StringLength(128)]
        public required string Image { get; set; }

        [Range(0, 60)]
        public int DeliveryTimeInMinutes { get; set; }

        public List<Ingredient> Ingredients { get; set; } = [];

        public List<Order> Orders { get; set; } = [];

    }
}
