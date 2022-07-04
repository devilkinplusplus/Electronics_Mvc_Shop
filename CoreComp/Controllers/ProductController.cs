using CoreComp.Models;
using CoreComp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace CoreComp.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var data = productRepository.TList("Country");
            data = productRepository.TList("Category");
            return View(data.ToPagedList(page,5));
        }

        [HttpGet]
        public IActionResult NewProduct()
        {
            DropDownValues();
            return View();
        }


        [HttpPost]
        public IActionResult NewProduct(Product prod)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please Fill Up !";
                return RedirectToAction("NewProduct");
            }
            productRepository.TAdd(prod);
            TempData["AlertMessage"] = "Created Succesfully !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            DropDownValues();
            var data = productRepository.TGet(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product prod)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please Fill Up !";
                return RedirectToAction("UpdateProduct");
            }
            var data = productRepository.TGet(prod.ProdId);
            data.ProdName = prod.ProdName;
            data.CountryId = prod.CountryId;
            data.CategoryId = prod.CategoryId;
            data.ProdPrice = prod.ProdPrice;
            data.ProdStock = prod.ProdStock;
            data.ImageUrl = prod.ImageUrl;
            productRepository.TUpdate(data);
            TempData["AlertMessage"] = "Updated Succesfully !";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var data = productRepository.TGet(id);
            productRepository.TDelete(data);
            return RedirectToAction("Index");
        }

        private void DropDownValues()
        {
            List<SelectListItem> countries = (from x in c.Countries.ToList()
                                              select new SelectListItem
                                              {
                                                  Value = x.CountryId.ToString(),
                                                  Text = x.CountryName
                                              }
                                       ).ToList();
            List<SelectListItem> catagories = (from y in c.Categories.ToList().Where(x=>x.Status==true)
                                               select new SelectListItem
                                               {
                                                   Value = y.CategoryId.ToString(),
                                                   Text = y.CategoryName
                                               }).ToList();
            ViewBag.cntry = countries;
            ViewBag.ctgr = catagories;
        }
    }
}
