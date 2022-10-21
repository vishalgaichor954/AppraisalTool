using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.App.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login","Login");
            }
            //HttpContext.Session.SetString("Role", "User");
            //HttpContext.Session.SetString("LoggedIn", "True");
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if(user != null)
            {
                ViewBag.FullName = user.Name;
                ViewBag.UserRole = user.Role;
            }
            JobProfilesViewmodel jobProfiles = new JobProfilesViewmodel();
            //{
            //       PrimaryRole="Savings Account Officer",
            //       SecondaryRole="Current Account Officer",
            //    Roles = { "Job Profile1","Job Profile2","Job Profile3","job profile4"}
            //};
            jobProfiles.PrimaryRole = "Savings Account Officer";
            jobProfiles.SecondaryRole = "Current Account Officer";
            jobProfiles.Roles = new List<string>() { "Job Profile1", "Job Profile2", "Job Profile3", "job profile4" };



            return View(jobProfiles);
        }
    }
}
