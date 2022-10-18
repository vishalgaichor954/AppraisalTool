using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.App.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            string x = HttpContext.Session.GetString("Role");
            if(x != null)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View();
        }
    }
}
