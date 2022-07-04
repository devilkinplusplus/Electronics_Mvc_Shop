using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreComp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryDetails(int id)
        {
            ViewBag.x = id;
            return View();
        }

        public IActionResult CountryList()
        {
            return View();
        }

        //Partial
        public IActionResult AboutUs()
        {
            return View();
        }
      

    }
}
