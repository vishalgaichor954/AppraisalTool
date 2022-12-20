using AppraisalTool.App.Dtos;
using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Services.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class AuthorityController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;

        public AuthorityController(IMapper mapper, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _protector = provider.CreateProtector("");
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult GetAllAuthority()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            client = new HttpClient();
            client.BaseAddress = baseAddress;
            List<UserViewModel> modellist = new List<UserViewModel>(); ;



            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/GetALlUserList?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<UserViewModel> mylist = JsonConvert.DeserializeObject<List<UserViewModel>>(JsonConvert.SerializeObject(res.Data));
                ViewBag.UserList = _mapper.Map<IEnumerable<UserEncodeDto>>(mylist); ;
                return View();

            }
            return View();
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult AssignAuthority(string? id)
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null)
            {
                return RedirectToAction("GetAllAuthority", "Admin");
            }
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            AssignAuthorityVm user = new AssignAuthorityVm();
            //User/getUser?id=1&api-version=1
            int unprotectedId = int.Parse(_protector.Unprotect(id));

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"User/getUser?id={unprotectedId}&api-version=1").Result;
            HttpResponseMessage Reporting = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=2&api-version=1").Result;
            HttpResponseMessage Reviewing = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=3&api-version=1").Result;
            HttpResponseMessage admin = client.GetAsync(client.BaseAddress + "User/getUserByRoleId?id=1&api-version=1").Result;

            if (response.IsSuccessStatusCode  && Reporting.IsSuccessStatusCode && Reviewing.IsSuccessStatusCode)
            {

                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                user = JsonConvert.DeserializeObject<AssignAuthorityVm>(serres);

               
                //Reporting Authority dropdown
                var reportingData = Reporting.Content.ReadAsStringAsync().Result;
                var repata = JsonConvert.DeserializeObject<Response>(reportingData);
                Console.WriteLine(repata.Data);
                List<SelectListItem> ReportingList = new List<SelectListItem>();
                foreach (var item in repata.Data)
                {

                    ReportingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString(), Selected = user.RepaId == (int)item.id });

                }

                //reviewing authority dropdown
                var ReviewingData = Reviewing.Content.ReadAsStringAsync().Result;
                var Reviewingdata = JsonConvert.DeserializeObject<Response>(ReviewingData);
                Console.WriteLine(Reviewingdata.Data);
                List<SelectListItem> ReviewingList = new List<SelectListItem>();
                foreach (var item in Reviewingdata.Data)
                {

                    ReviewingList.Add(new SelectListItem { Text = item.firstName.ToString() + " " + item.lastName.ToString(), Value = item.id.ToString(), Selected = user.RevaId == (int)item.id });
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
              
                ViewBag.ReportingList = ReportingList;
                ViewBag.ReviewingList = ReviewingList;
                Console.WriteLine(user);



            }
            return View(user);
        }

        [HttpPost]
        public IActionResult AssignAuthority(AssignAuthorityVm model)
        {

            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            //model.UpdatedBy = userSession.UserId;
            string data = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("https://localhost:5000/api/User/AssignAuthority?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Authority"] = "Updated Successfully";
                return RedirectToAction("GetAllAuthority");
            }
            TempData["AuthorityError"] = "Failed to Update User";
            return RedirectToAction("GetAllAuthority");



        }

    }
}
