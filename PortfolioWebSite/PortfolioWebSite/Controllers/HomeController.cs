using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using PortfolioWebSite.DAL;
using PortfolioWebSite.Models;
using PortfolioWebSite.ViewsModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;



namespace PortfolioWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, AppDbContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            var home = new HomeVM
            {
                About = await _context.Abouts.FirstOrDefaultAsync(),
                AboutsSites = await _context.AboutsSites.ToListAsync(),
                Favorite = await _context.Favorites.FirstOrDefaultAsync(),
                Percents = await _context.Percents.ToListAsync(),
                SIcons = await _context.SIcons.ToListAsync(),
                Skill = await _context.Skills.FirstOrDefaultAsync(),
                Testimonials = await _context.Testimonials.FirstOrDefaultAsync(),
                TestimonialsEdits = await _context.TestimonialsEdits.ToListAsync(),
                Contact = await _context.Contacts.FirstOrDefaultAsync(),
                ContactLocations = await _context.ContactLocations.ToListAsync(),
                Cvs = await _context.Cvs.FirstOrDefaultAsync()
            };
            return View(home);
        }


        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Index", model);
            }

            var message = new MailMessage();
            message.From = new MailAddress("elekberovulvi520@gmail.com");
            message.To.Add("elekberovulvi956@gmail.com");
            message.Subject = model.Subject;
            message.Body = $"Ad: {model.Name}\nEmail: {model.Email}\nMesaj: {model.Message}\nBaşlıq: {model.Subject}";

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("aze24932@gmail.com", "euhhbmxebclvrjqh");
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
    }
