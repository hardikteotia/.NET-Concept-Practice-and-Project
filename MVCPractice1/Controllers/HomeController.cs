using Microsoft.AspNetCore.Mvc;
using MVCPractice1.Models;

namespace MVCPractice1.Controllers
{
    public class HomeController : BaseController
    {
        StudentDAL sDAlObj = new StudentDAL();
        public IActionResult Index()
        {
            List<Student> students = sDAlObj.GetStudents();
            return View("Index", students);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AfterCreate(Student student)
        {
            sDAlObj.AddStudent(student);
            return Redirect("/Home/Index");
        }

    }
}
