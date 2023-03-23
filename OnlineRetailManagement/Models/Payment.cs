using System.ComponentModel.DataAnnotations;

namespace OnlineRetailManagement.Models
{
    public class Payment
    {
       
        public string cardnumber { get; set; }
        public int cvv { get; set; }
        public string expirydate { get; set; }

    }
}
