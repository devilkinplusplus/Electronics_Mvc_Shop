using CoreComp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreComp.Controllers
{
    public class StatsController : Controller
    {
        Context c = new Context();
        public IActionResult Statistics()
        {
            //count of products
            var prodCount = c.Products.Count();
            ViewBag.pC = prodCount;


            //Count of Categories
            var categCount = c.Categories.Where(x => x.Status == true).Count();
            ViewBag.cCount = categCount;

            //Count of Electronics (Phone and Laptop)
            var elecCount = c.Products.Where(x => x.Category.CategoryName == "Phone" || x.Category.CategoryName == "Notebook").Count();
            ViewBag.elecC = elecCount;

            //Count of foods
            var phoneCount = c.Products.Where(x => x.Category.CategoryName == "Phone").Count();
            ViewBag.phoneC = phoneCount;

            //Sum of Products
            var sumPrice = c.Products.Sum(x => x.ProdPrice);
            ViewBag.sumPr = sumPrice;

            //Max products exporter country
            var mostRepeated = c.Products
                                    .GroupBy(q => q.CountryId)
                                    .OrderByDescending(gp => gp.Count())
                                    .Take(1)
                                    .Select(g => g.Key).FirstOrDefault();
            var bestSeller = c.Products.Where(x => x.CountryId == mostRepeated).Select(x => x.Country.CountryName).FirstOrDefault();

            ViewBag.export = bestSeller;

            //top seller
            var topSeller = c.Products.Max(x => x.ProdStock);
            var topSeller2 = c.Products.Where(x => x.ProdStock == topSeller).Select(x => x.ProdName).FirstOrDefault();
            ViewBag.topS = topSeller2;

            //Average price
            var averagePrice = c.Products.Average(x => x.ProdPrice);
            ViewBag.avrgPrice = Math.Round(averagePrice, 1);

            //Expensive
            var mostExpensive = c.Products.Max(x => x.ProdPrice);
            var mostExpensiveProd = c.Products.Where(x => x.ProdPrice == mostExpensive).Select(x => x.ProdName).FirstOrDefault();
            ViewBag.expensive = mostExpensiveProd;

            //Cheap
            var cheap = c.Products.Min(x => x.ProdPrice);
            var cheapProd = c.Products.Where(x => x.ProdPrice == cheap).Select(x => x.ProdName).FirstOrDefault();
            ViewBag.cheaps = cheapProd;

            //Random Product
            Random rand = new Random();
            int toSkip = rand.Next(1, c.Products.Count());
            var randomObject = c.Products.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).First();
            ViewBag.ywl = randomObject.ProdName;

            //Total Stock
            var totalStock = c.Products.Sum(x => x.ProdStock);
            ViewBag.ts = totalStock;

            return View();
        }
    }
}
