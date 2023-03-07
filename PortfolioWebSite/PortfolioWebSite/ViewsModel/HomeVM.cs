using PortfolioWebSite.Models;
using System.Web.Mvc;

namespace PortfolioWebSite.ViewsModel
{
    public class HomeVM
    {
        public Favorite Favorite { get; set; }
        public List<SIcons> SIcons { get; set; }
        public About About { get; set; }
        public Cv Cvs { get; set; }
        public List<AboutsSite> AboutsSites { get; set; }
        public Skill Skill { get; set; }
        public List<Percent> Percents { get; set; }
        public Testimonials Testimonials { get; set; }
        public List<TestimonialsEdit> TestimonialsEdits { get; set; }

        public Contact Contact { get; set; }
        public List<ContactLocation> ContactLocations { get; set; }
        public ContactFormModel ContactFormModel { get; set; }
    }
}
