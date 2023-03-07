using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebSite.Models;

namespace PortfolioWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AdminController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model.Email == "elekberovulvi520@gmail.com" && model.Password == "ulvifcbgts") 
            {

                HttpContext.Session.SetString("Email", model.Email);

                return RedirectToAction("Index","Dashboard");
            
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email və ya Şifrə yanlışdır.");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Email");
            return RedirectToAction("Login");
        }
    }
}
