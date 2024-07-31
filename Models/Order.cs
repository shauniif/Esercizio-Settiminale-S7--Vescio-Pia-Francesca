using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        public string ExtraNote { get; set; }

        public bool IsProcessed { get; set; } = false;

        public User User { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }
}
