using System.ComponentModel.DataAnnotations;

namespace PortfolioWebSite.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
