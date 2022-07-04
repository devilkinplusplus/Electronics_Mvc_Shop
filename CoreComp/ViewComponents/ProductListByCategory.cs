using CoreComp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreComp.ViewComponents
{
    public class ProductListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ProductRepository productRepository = new ProductRepository();
            var foodList = productRepository.List(x => x.CategoryId == id);
            return View(foodList);
        }
    }
}
