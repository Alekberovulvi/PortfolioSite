using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebSite.DAL;
using PortfolioWebSite.Models;
using PortfolioWebSite.ViewsModel;

namespace PortfolioWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM home = new HomeVM
            {
                About = await _context.Abouts.FirstOrDefaultAsync(),
                Cvs = await _context.Cvs.FirstOrDefaultAsync()
            };
            return View(home);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about)
        {
            _context.Add(about);
                await _context.SaveChangesAsync();
            
                return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var x = await _context.Abouts.FindAsync(id);
            return View(x);
        }

        [HttpPost]
        public async Task<IActionResult> Update(About about)
        {
            var existing = await _context.Abouts.FindAsync(about.Id);
            existing.Title = about.Title;
            existing.Description = about.Description;
            existing.Name = about.Name;
            existing.Img= about.Img;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


       
    }
}
