using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebSite.DAL;
using PortfolioWebSite.Models;
using PortfolioWebSite.ViewsModel;
using System.Runtime.InteropServices;

namespace PortfolioWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AboutIndexController : Controller
    {
        private readonly AppDbContext _context;
        public AboutIndexController(AppDbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                AboutsSites = await _context.AboutsSites.ToListAsync()
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutsSite aboutsSite)
        {
            _context.Add(aboutsSite);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var x = await _context.AboutsSites.FindAsync(id);
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutsSite aboutsSite)
        {
           var existing = await _context.AboutsSites.FindAsync(aboutsSite.Id);
            existing.Icon = aboutsSite.Icon;
            existing.Brithday = aboutsSite.Brithday;
            existing.Phone = aboutsSite.Phone;
            existing.Email = aboutsSite.Email;
            existing.City = aboutsSite.City;
            existing.Degree = aboutsSite.Degree; 
            existing.Freelance = aboutsSite.Freelance;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.AboutsSites.FindAsync(id);
            _context.AboutsSites.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
