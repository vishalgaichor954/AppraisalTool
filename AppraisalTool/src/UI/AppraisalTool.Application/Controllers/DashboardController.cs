using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.AppraisalToolDashboard;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppraisalTool.App.Controllers
{
    public class DashboardController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");
        public IActionResult Index()
        {
            return View();
        }

        //@Author : Abhishek Singh
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
        //https://localhost:5000/api/Auth/getAllCards?id=1&api-version=1
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/Auth/getAllCards?id={user.RoleId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                dynamic json = JsonConvert.DeserializeObject(res.Data);
                //var menuList = JsonConvert.DeserializeObject<List<MenuListViewModel>>(json);
                ViewBag.GetMenuCards = json;

                
                //if (res.Succeeded == true)
                //{
                //    return Json(true);
                //}
                //else
                //{
                //    return Json(false);
                //}
               


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
