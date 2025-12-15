using Microsoft.AspNetCore.Mvc;
using MVCDemo.Model;
//using LoggerLibrary;
using MVCDemo.Filters;
namespace MVCDemo.Controllers
{
    
    public class LoginController : Controller
    {
        [LogFilter]
        public IActionResult SignIn()
        {
            ViewBag.Title = "Sign In Here!";
            ViewBag.UserName = "Guest";

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                if(user.UserName == "test" && user.Password == "test@123")
                {
                    HttpContext.Session.SetString("UserName", user.UserName);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Message = "Credentials are incorrect!";
                    return View(user);
                }
            }
            else
            {
                return View();
            }

        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("UserName");
            return Redirect("/Login/SignIn");
        }
    }
}
