using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCDemo.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UserName") == null || context.HttpContext.Session.GetString("UserName") == "")
            {
                context.HttpContext.Response.Redirect("/Login/SignIn");
            }
            
        }
    }
}
