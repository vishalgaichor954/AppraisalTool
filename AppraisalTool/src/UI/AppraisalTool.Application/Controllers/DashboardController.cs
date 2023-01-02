﻿using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.AppraisalToolDashboard;
using AppraisalTool.App.Models.Navbar;
using AppraisalTool.App.Services.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace AppraisalTool.App.Controllers
{
    public class DashboardController : Controller
    {
        Uri baseAddress;

        public DashboardController(IConfiguration configuration)
        {
            baseAddress = new Uri(configuration.GetValue<string>("BaseUrl"));
        }

        public IActionResult Index()
        {
            return View();
        }

        //@Author : Abhishek Singh-- lOADING Job Profiles and Dashboard Menu Dynamically.
        public IActionResult Dashboard()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if (user != null)
            {
                ViewBag.FullName = user.Name;
                ViewBag.UserRole = user.Role;

            }

            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"User/GetAllCard?id={user.RoleId}&api-version=1").Result;
            if (cardResponse.IsSuccessStatusCode)
            {
                var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                dynamic json = JsonConvert.DeserializeObject(responseData);


                NavbarViewModel navbarVM = new NavbarViewModel() { UserRole = user.Role, UserName = user.Name, SideBarList = json.data,UserId=user.UserId };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "navbarViewModel", navbarVM);


                ViewBag.GetMenuCards = json.data;

                ViewBag.GetSideBarData = json.data;
            }


            //Api call to get dashboard 
            HttpResponseMessage responses = client.GetAsync(client.BaseAddress + $"User/GetUserJobProfile?id={user.UserId}&api-version=1").Result;
            JobProfilesViewmodel jobProfiles = new JobProfilesViewmodel();
            if (responses.IsSuccessStatusCode)
            {
                var responseData = responses.Content.ReadAsStringAsync().Result;

                var ress = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                jobProfiles.PrimaryRole = ress.Data.primaryRole;
                jobProfiles.SecondaryRole = ress.Data.secondaryRole;
                var jobProfileList = new List<string>();

                foreach (string item in ress.Data.roles)
                {
                    jobProfileList.Add(item);
                }

                jobProfiles.Roles = jobProfileList;
            }

            return View(jobProfiles);
        }
    }
}
