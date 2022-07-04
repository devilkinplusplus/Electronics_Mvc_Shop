using CoreComp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreComp.ViewComponents
{
    public class ProductList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ProductRepository productRepository = new ProductRepository();
            var prod = productRepository.TList();
            return View(prod);
        }
    }
}
