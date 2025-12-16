using Microsoft.AspNetCore.Mvc;
using MVCPractice3.Models;

namespace MVCPractice3.Controllers
{
    public class HomeController : Controller
    {

        productdal dalobj = new productdal();
        public IActionResult Index()
        {
            List<productpoco> allprods =  dalobj.getAllProducts();
            return View(allprods);
        }

        public IActionResult Delete(int id)
        {
            int rowsAffected = dalobj.Delete(id);

            return Redirect("/Home/Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(productpoco product)
        {
            int rowsAffectted = dalobj.Add(product);
            return Redirect("/Home/Index");
        }

        public IActionResult Edit(int id)
        {
            productpoco prod = dalobj.GetOneProd(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(productpoco product)
        {
            int rowsaffected = dalobj.Update(product);
            return Redirect("/Home/Index");
        }

    }
}
