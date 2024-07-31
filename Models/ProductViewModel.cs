using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Il nome del prodotto è obbligatorio")]
        public required string Name { get; set; }

        [Range(0, 50)]
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "L'immagine è obbligatoria")]
        public IFormFile Image { get; set; }

        [Range(0, 60)]
        [Required]
        public int DeliveryTimeInMinutes { get; set; }

        public List<Ingredient> Ingredients { get; set; } = [];

    }
}
