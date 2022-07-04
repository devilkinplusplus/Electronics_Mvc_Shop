using CoreComp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreComp.ViewComponents
{
    public class CountryList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var countryL = c.Countries.ToList();
            return View(countryL);
        }

    }
}
