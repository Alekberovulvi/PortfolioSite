using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebSite.DAL;
using PortfolioWebSite.Models;
using PortfolioWebSite.ViewsModel;
using System.Security.AccessControl;

namespace PortfolioWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ExpressionController : Controller
    {
        private readonly AppDbContext _context;
        public ExpressionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Testimonials = await _context.Testimonials.FirstOrDefaultAsync(),
                TestimonialsEdits = await _context.TestimonialsEdits.ToListAsync()
            };
            return View(homeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonials testimonials)
        {
            _context.Testimonials.Add(testimonials);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var x = await _context.Testimonials.FindAsync(id);
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Testimonials testimonials)
        {
            var existing = await _context.Testimonials.FindAsync(testimonials.Id);
            existing.Title = testimonials.Title;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.Testimonials.FindAsync(id);
            _context.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Pcreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pcreate(TestimonialsEdit testimonialsEdit)
        {
            _context.TestimonialsEdits.Add(testimonialsEdit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Pupdate(int id)
        {
            var x = await _context.TestimonialsEdits.FindAsync(id);
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pupdate(TestimonialsEdit testimonialsEdit)
        {
            var ex = await _context.TestimonialsEdits.FindAsync(testimonialsEdit.Id);
            ex.Img = testimonialsEdit.Img;
            ex.Name = testimonialsEdit.Name;
            ex.Title= testimonialsEdit.Title;
            ex.Icon = testimonialsEdit.Icon;
            ex.Description = testimonialsEdit.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pdelete(int id)
        {
            var del = await _context.TestimonialsEdits.FindAsync(id);
            _context.Remove(del);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
