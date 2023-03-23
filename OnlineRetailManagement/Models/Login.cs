using Microsoft.Build.Framework;

namespace OnlineRetailManagement.Models
{
    public class Login
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
