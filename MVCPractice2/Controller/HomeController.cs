using Microsoft.AspNetCore.Mvc;
using MVCPractice2.Models;

namespace MVCPractice2.Controllers
{
    public class HomeController : Controller
    {
        CompanyModelDAL dalobj = new CompanyModelDAL();
        public IActionResult Index()
        {
            List<CompanyModel> empList = new List<CompanyModel>();
            empList = dalobj.GetAllEmp();
            return View(empList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyModel emp)
        {
            int rowsAffected = dalobj.Create(emp);

            return Redirect("/Home/Index");
        }

        
        public IActionResult Delete(int id)
        {
            int rowsAffected = dalobj.Delete(id);
            return Redirect("/Home/Index");
        }

        public IActionResult Edit(int id) {
            CompanyModel emp = dalobj.GetSingleEmp(id);

            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(CompanyModel emp) {
            int rowsAffected = dalobj.Update(emp);
            return Redirect("/Home/Index");
        }
    }
}
