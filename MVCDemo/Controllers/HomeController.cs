using Microsoft.AspNetCore.Mvc;
using MVCDemo.Filters;
using MVCDemo.Model;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVCDemo.Controllers
{
    [LogFilter]
    public class HomeController : Controller
    {

        MyStudentViewModel svm = new MyStudentViewModel();

        [AuthFilter]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.UserName = GetUserName();

            List<MyStudent> listOfStudents = svm.GetAllStudents();

            return View(listOfStudents);
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us!";
            ViewBag.UserName = GetUserName();
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us!";
            ViewBag.UserName = GetUserName(); 
            return View();
        }
        
        private string GetUserName()
        {
            if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("UserName") != "")
            {
                return HttpContext.Session.GetString("UserName");
            }
            else
            {
                return "Guest";
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [AuthFilter]
        [HttpPost]
        public IActionResult Create(MyStudent student)
        {
            if (ModelState.IsValid)
            {
                svm.AddStudent(student);
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.Message = "something is not right with the data";
                return View(student);
            }
        }

        [AuthFilter]
        public IActionResult Edit(int id)
        {
            MyStudent student = svm.GetStudentByNumber(id);
            return View(student);
        }



        [AuthFilter]
        [HttpPost]
        public IActionResult Edit(MyStudent updatedStudent)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected = svm.UpdateStudent(updatedStudent);

                if (rowsAffected > 0)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Message = "Failed to update the record!";
                    return View(updatedStudent);
                }
            }
            else
            {
                ViewBag.Message = "something is not right with the data!";
                return View(updatedStudent);
            }
        }

        [AuthFilter]
        public IActionResult Delete(int id)
        {
            svm.DeleteStudent(id);
            return Redirect("/Home/Index");
        }

    }
}
