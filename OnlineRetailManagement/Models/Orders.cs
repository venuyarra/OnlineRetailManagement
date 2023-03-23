using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineRetailManagement.Models
{
    public class Orders
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("cart")]
        public int CartId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double totalprice { get; set; }
        public Cart cart { get; set; }

    }
}
