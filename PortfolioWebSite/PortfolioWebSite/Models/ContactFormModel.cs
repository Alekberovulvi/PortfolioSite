using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace PortfolioWebSite.Models
{
    public class ContactFormModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu xana mütləq doldurulmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana mütləq doldurulmalıdır.")]
        [EmailAddress(ErrorMessage ="Email Ünvanı Daxil Edin...")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Bu xana mütləq doldurulmalıdır.")]
        public string Message { get; set; }

    }
}
