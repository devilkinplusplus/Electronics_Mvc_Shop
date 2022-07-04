using CoreComp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreComp.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var ctg= categoryRepository.TList();
            return View(ctg);
        }
    }
}
