using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polly;
using PortfolioWebSite.DAL;
using PortfolioWebSite.Models;
using PortfolioWebSite.ViewsModel;

namespace PortfolioWebSite.Areas.Manage.Controllers
{
    [Area("manage")]

    public class IconController : Controller
    {
        private readonly AppDbContext _dbContext;
        public IconController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                SIcons = await _dbContext.SIcons.ToListAsync()
            };
            return View(homeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SIcons s)
        {
            _dbContext.SIcons.Add(s);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public async Task<IActionResult> Update(int id)
        {
            var x = await _dbContext.SIcons.FindAsync(id);
            return View(x);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SIcons icons)
        {
            var existing = await _dbContext.SIcons.FindAsync(icons.Id);
            existing.Social = icons.Social;
            existing.Link = icons.Link;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var del = await _dbContext.SIcons.FindAsync(id);
            _dbContext.SIcons.Remove(del);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
