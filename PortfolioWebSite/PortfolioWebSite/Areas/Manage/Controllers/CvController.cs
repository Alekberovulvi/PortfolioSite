using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;
using PortfolioWebSite.DAL;
using PortfolioWebSite.Models;
using PortfolioWebSite.ViewsModel;

namespace PortfolioWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CvController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public CvController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeVM
            {
                Cvs = await _context.Cvs.FirstOrDefaultAsync()
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
        public async Task<IActionResult> Create(IFormFile file)
        {
            if (file == null || file.Length == 0) 
            {
                ModelState.AddModelError("file", "Please select a file.");
                return View();
            }

            var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
            var fileExtension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("file", "Invalid file format. Only PDF, DOC, and DOCX files are allowed.");
                return View();
            }


            var filename = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/assets/cv",filename);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var cv = new Cv
            {
                FileName = filename,
                Name = file.FileName
            };

            _context.Cvs.Add(cv);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cv = await _context.Cvs.FindAsync(id);
            if (cv == null)
                return NotFound();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "cv", cv.FileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            _context.Cvs.Remove(cv);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
