using AppraisalTool.App.Models;
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
