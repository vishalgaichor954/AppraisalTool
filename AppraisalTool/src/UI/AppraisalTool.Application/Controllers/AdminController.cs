﻿using AppraisalTool.App.Dtos;
using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Services.CustomAttributes;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace AppraisalTool.App.Controllers
{


    public class AdminController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;

        public AdminController(IMapper mapper, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _protector = provider.CreateProtector("");
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult CreateUser()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            client = new HttpClient();
            client.BaseAddress = baseAddress;
            Console.WriteLine("Add Endpoint Hit");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/GetJobProfile?api-version=1").Result;
            HttpResponseMessage BranchReponse = client.GetAsync(client.BaseAddress + "User/GetBranch?api-version=1").Result;
            HttpResponseMessage RoleReponse = client.GetAsync(client.BaseAddress + "User/GetRole?api-version=1").Result;
            HttpResponseMessage Reporting = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=2&api-version=1").Result;
            HttpResponseMessage Reviewing = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=3&api-version=1").Result;
            HttpResponseMessage admin = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=1&api-version=1").Result;


            if (response.IsSuccessStatusCode && BranchReponse.IsSuccessStatusCode && RoleReponse.IsSuccessStatusCode && Reporting.IsSuccessStatusCode && Reviewing.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data.Data);
                List<SelectListItem> JobProfileRolelist = new List<SelectListItem>();
                foreach (var item in data.Data)
                {

                    JobProfileRolelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.id.ToString() });

                }
                var branchresponseData = BranchReponse.Content.ReadAsStringAsync().Result;

                var branchdata = JsonConvert.DeserializeObject<Response>(branchresponseData);
                Console.WriteLine(branchdata.Data);

                List<SelectListItem> branchlist = new List<SelectListItem>();
                foreach (var item in branchdata.Data)
                {

                    branchlist.Add(new SelectListItem { Text = item.branchName.ToString(), Value = item.id.ToString() });

                }
                var RoleResponseData = RoleReponse.Content.ReadAsStringAsync().Result;
                var Roledata = JsonConvert.DeserializeObject<Response>(RoleResponseData);
                Console.WriteLine(Roledata.Data);
                List<SelectListItem> Rolelist = new List<SelectListItem>();
                foreach (var item in Roledata.Data)
                {

                    Rolelist.Add(new SelectListItem { Text = item.role.ToString(), Value = item.id.ToString() });

                }
                //Reporting Authority dropdown
                var reportingData = Reporting.Content.ReadAsStringAsync().Result;
                var repata = JsonConvert.DeserializeObject<Response>(reportingData);
                Console.WriteLine(repata.Data);
                List<SelectListItem> ReportingList = new List<SelectListItem>();
                foreach (var item in repata.Data)
                {

                    ReportingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });

                }

                //reviewing authority dropdown
                var ReviewingData = Reviewing.Content.ReadAsStringAsync().Result;
                var Reviewingdata = JsonConvert.DeserializeObject<Response>(ReviewingData);
                Console.WriteLine(Reviewingdata.Data);
                List<SelectListItem> ReviewingList = new List<SelectListItem>();
                foreach (var item in Reviewingdata.Data)
                {

                    ReviewingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });
                }
                //admin dropdown
                var adminData = admin.Content.ReadAsStringAsync().Result;
                var admindata = JsonConvert.DeserializeObject<Response>(adminData);
                Console.WriteLine(admindata.Data);

                foreach (var item in admindata.Data)
                {

                    ReportingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });
                    ReviewingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.ToString() });
                }
                ViewBag.JobProfileRolelist = JobProfileRolelist;
                ViewBag.branchlist = branchlist;
                ViewBag.Rolelist = Rolelist;
                ViewBag.ReportingList = ReportingList;
                ViewBag.ReviewingList = ReviewingList;


                return View();
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult CreateUser(UserViewModel model)
        {

            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

           
                model.AddedBy = userSession.UserId;
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "User/RegisterUser?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddUserSuccess"] = "User Created Successfully";
                    return RedirectToAction("GetAllAuthority", "Authority");
                }
            
            TempData["AddUserFailed"] = "Faild to Register User";
            return RedirectToAction("GetAllAuthority", "Authority");
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult UpdateUser(string? id)
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return RedirectToAction("ListUsers", "Admin");
            }
            int unprotectedId = 0;
            
            try
            {
                unprotectedId = int.Parse(_protector.Unprotect(id));
            }catch(Exception e)
            {
                return RedirectToAction("ListUsers", "Admin");
            }
            
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            EditUserViewModel user = new EditUserViewModel();
            //User/getUser?id=1&api-version=1
            HttpResponseMessage jobProfileresponse = client.GetAsync(client.BaseAddress + "User/GetJobProfile?api-version=1").Result;
            HttpResponseMessage BranchReponse = client.GetAsync(client.BaseAddress + "User/GetBranch?api-version=1").Result;
            HttpResponseMessage RoleReponse = client.GetAsync(client.BaseAddress + "User/GetRole?api-version=1").Result;

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"User/getUser?id={unprotectedId}&api-version=1").Result;
            HttpResponseMessage Reporting = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=2&api-version=1").Result;
            HttpResponseMessage Reviewing = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=3&api-version=1").Result;
            HttpResponseMessage admin = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=1&api-version=1").Result;

            if (response.IsSuccessStatusCode && jobProfileresponse.IsSuccessStatusCode && BranchReponse.IsSuccessStatusCode && RoleReponse.IsSuccessStatusCode && Reporting.IsSuccessStatusCode && Reviewing.IsSuccessStatusCode)
            {

                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                user = JsonConvert.DeserializeObject<EditUserViewModel>(serres);
                user.Id = unprotectedId;

                //bind data from database
                var responseData = jobProfileresponse.Content.ReadAsStringAsync().Result;
                var data1 = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data1.Data);
                List<SelectListItem> JobProfileRolelist = new List<SelectListItem>();
                foreach (var item in data1.Data)
                {

                    JobProfileRolelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.id.ToString(), Selected = user.PrimaryJobProfileId == (int)item.id });

                }
                var branchresponseData = BranchReponse.Content.ReadAsStringAsync().Result;

                var branchdata = JsonConvert.DeserializeObject<Response>(branchresponseData);
                Console.WriteLine(branchdata.Data);

                List<SelectListItem> branchlist = new List<SelectListItem>();
                foreach (var item in branchdata.Data)
                {

                    branchlist.Add(new SelectListItem { Text = item.branchName.ToString(), Value = item.id.ToString(), Selected = user.BranchId == (int)item.id });

                }
                var RoleResponseData = RoleReponse.Content.ReadAsStringAsync().Result;
                var Roledata = JsonConvert.DeserializeObject<Response>(RoleResponseData);
                Console.WriteLine(Roledata.Data);
                List<SelectListItem> Rolelist = new List<SelectListItem>();
                foreach (var item in Roledata.Data)
                {

                    Rolelist.Add(new SelectListItem { Text = item.role.ToString(), Value = item.id.ToString(), Selected = user.Role == (int)item.id });

                }

                //Reporting Authority dropdown
                //Reporting Authority dropdown
                var reportingData = Reporting.Content.ReadAsStringAsync().Result;
                var repata = JsonConvert.DeserializeObject<Response>(reportingData);
                Console.WriteLine(repata.Data);
                List<SelectListItem> ReportingList = new List<SelectListItem>();
                foreach (var item in repata.Data)
                {

                    ReportingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });

                }

                //reviewing authority dropdown
                var ReviewingData = Reviewing.Content.ReadAsStringAsync().Result;
                var Reviewingdata = JsonConvert.DeserializeObject<Response>(ReviewingData);
                Console.WriteLine(Reviewingdata.Data);
                List<SelectListItem> ReviewingList = new List<SelectListItem>();
                foreach (var item in Reviewingdata.Data)
                {

                    ReviewingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });
                }
                //admin dropdown
                var adminData = admin.Content.ReadAsStringAsync().Result;
                var admindata = JsonConvert.DeserializeObject<Response>(adminData);
                Console.WriteLine(admindata.Data);

                foreach (var item in admindata.Data)
                {

                    ReportingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });
                    ReviewingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString() });
                }
                ViewBag.JobProfileRolelist = JobProfileRolelist;
                ViewBag.branchlist = branchlist;
                ViewBag.Rolelist = Rolelist;
                ViewBag.ReportingList = ReportingList;
                ViewBag.ReviewingList = ReviewingList;
                Console.WriteLine(user);



            }
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(EditUserViewModel model)
        {

            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            model.UpdatedBy = userSession.UserId;
            string data = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"https://localhost:5000/api/User/UpdateUser?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "User Updated Successfully";
                return RedirectToAction("ListUsers");
            }
            TempData["editError"] = "Failed to Update User";
            return RedirectToAction("ListUsers");



        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ListUsers()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            client = new HttpClient();
            client.BaseAddress = baseAddress;
            List<UserViewModel> modellist = new List<UserViewModel>(); 
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<UserViewModel> mylist = JsonConvert.DeserializeObject<List<UserViewModel>>(JsonConvert.SerializeObject(res.Data));
                ViewBag.UserList = _mapper.Map<IEnumerable<UserEncodeDto>>(mylist); 
                return View();
            }
            return View();
        }

        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult DeleteUser(string id)
        {
            int unprotectedId = int.Parse(_protector.Unprotect(id));
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            UserViewModel user = new UserViewModel();
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"User/removeUser?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);

                TempData["DeleteuserSuccess"] = "User Delete Successfully";
                return RedirectToAction("ListUsers");
            }
            TempData["DeleteUserFaild"] = "Faild to Delete User";
            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ConfigureSetting()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"User/GetAllCard?id={user.RoleId}&api-version=1").Result;
            if (cardResponse.IsSuccessStatusCode)
            {
                var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                dynamic json = JsonConvert.DeserializeObject(responseData);
                ViewBag.GetMenuCards = json.data;


            }
            return View();
        }



        [HttpGet]
        public JsonResult UserExistsEmail(string email)
        {
            //https://localhost:5000/api/Auth?email=ssabhishek00%40gmail.com&api-version=1
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Auth?email={email}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                if (res.Succeeded == true)
                {
                    return Json(false);
                }
                else
                {
                    return Json(true);
                }
            }
            return Json(true);
        }



        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ListAppraisals()
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync("https://localhost:5000/api/User/ListOfAppraisal?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(responseData);
                ViewBag.Appraisals = json.data;
                JArray items = (JArray)json.data;
                ViewBag.Empty = items.Count > 0 ? false : true;
                return View();

            }
            return View();
        }



        [HttpPost]
        public IActionResult ListAppraisals(List<AllowAppraisalEditVm> allowAppraisalEditVm)
        {
            AllowEditViewModel model = new AllowEditViewModel();
            foreach (var item in allowAppraisalEditVm)
            {
                model.AppraisalId = item.AppraisalId;
                model.Editable = item.IsAllowed;
            }
            Console.WriteLine(model);
            string data = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("https://localhost:5000/api/v1/AppraisalHome/AllowEdit", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["AllowSuccess"] = "Allowed To Edit Successfully";
                return RedirectToAction("ListAppraisals");
            }
            TempData["AllowFailed"] = "Oops!! Something Went Wrong";
            return RedirectToAction("ListAppraisals");



        }
    }

}

