using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
                About = await _context.Abouts.FirstOrDefaultAsync()
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

        public IActionResult Create([Bind("Id,Title,Description,Name")] About about, IFormFile imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null && imgFile.ContentType.ToLower().StartsWith("image/") &&
                    (imgFile.FileName.EndsWith(".jpg") || imgFile.FileName.EndsWith(".jpeg")))
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "assets", "img");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imgFile.CopyTo(fileStream);
                    }

                    about.Img = uniqueFileName;

                    _context.Add(about);
                    _context.SaveChanges();

                }
                else
                {
                    ModelState.AddModelError("imgFile", "Please choose a JPEG image file");
                }
            }

                    return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var x = await _context.Abouts.FindAsync(id);

            if (x == null)
            {
                return NotFound();
            }

            return View(x);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id ,About about, IFormFile file)
        {
            if (id != about.Id) 
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0) 
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg" };
                    var extension = Path.GetExtension(file.FileName);

                    if (!allowedExtensions.Contains(extension.ToLower()))
                    {
                        ModelState.AddModelError(string.Empty, "Only jpg/jpeg format is allowed.");
                        return View(about);
                    }
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName) + extension;
                    var filePath = Path.Combine(_env.WebRootPath, "wwwroot/assets/img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var oldFilePath = Path.Combine(_env.WebRootPath, "wwwroot/assets/img", about.Img);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                    about.Img = fileName;
                }
                try
                {
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Abouts.Any(e=>e.Id==id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(about);
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
