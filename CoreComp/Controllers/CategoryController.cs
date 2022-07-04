using CoreComp.Models;
using CoreComp.Repositories;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Linq;

namespace CoreComp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(int page=1)
        {
            return View(categoryRepository.TList().Where(x=>x.Status==true).ToPagedList(page,5));
        }


        [HttpGet]
        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCategory(Category categ)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            categoryRepository.TAdd(categ);
            TempData["AlertMessage"] = "Created Succesfully !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var data =categoryRepository.TGet(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category categ)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCategory");
            }
            TempData["AlertMessage"] = "Updated Succesfully !";
            var data = categoryRepository.TGet(categ.CategoryId);
            data.CategoryName = categ.CategoryName;
            data.Status = true;
            categoryRepository.TUpdate(data);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var data = categoryRepository.TGet(id);
            data.Status = false;
            categoryRepository.TUpdate(data);
            return RedirectToAction("Index");
        }

    }
}
