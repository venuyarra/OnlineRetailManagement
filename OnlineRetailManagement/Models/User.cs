using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineRetailManagement.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string email { get; set; }
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]).{8,32}$")]
        [Required]
        public string password { get; set; }
        [RegularExpression("^[6-9]\\d{9}$")]
        [Required]
        public string mobilenumber { get; set; }
        [Required]
        public string name { get; set; }
        public string address { get; set; }
        public ICollection<Cart> cart { get; set; }
    }
}
