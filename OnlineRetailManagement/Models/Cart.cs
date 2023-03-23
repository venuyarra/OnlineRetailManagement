using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRetailManagement.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int CartId { get; set; }
        [Required]
        [ForeignKey("user")]
        public String Email { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<ProductsInCart> ProductsInCart { get; set; }
        public ICollection<Orders> orders { get; set; }
        public User user { get; set; }
    }
}
