using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.UserRole;
using AppraisalTool.App.Services.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class UserRoleController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();

        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;

        public UserRoleController(IMapper mapper, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _protector = provider.CreateProtector("");
        }
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult AddUserRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUserRole(UserRole model)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            if (ModelState.IsValid)
            {
                model.AddedBy = userSession.UserId;
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Role/AddUserRole?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddUserSuccess"] = "User Role Added Successfully";
                    return RedirectToAction("ListUserRole");
                }
            }
            TempData["AddUserFailed"] = "Failed to Add User Role";
            return RedirectToAction("ListUserRole");

        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ListUserRole()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;


            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Role/GetUserRole?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<UserRole> mylist = JsonConvert.DeserializeObject<List<UserRole>>(JsonConvert.SerializeObject(res.Data));

                ViewBag.Role = _mapper.Map<IEnumerable<UserEncodedDto>>(mylist);
                return View();

            }
            return View();
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult UpdateUserRole(string id)
        {


            UserRole financialYear = new UserRole();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            int unprotectedId = int.Parse(_protector.Unprotect(id));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Role/GetUserRoleById?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                financialYear = JsonConvert.DeserializeObject<UserRole>(serres);
                //ViewBag.RoleList = menu;

                Console.WriteLine(financialYear);
            }
            return View(financialYear);
        }

        [HttpPost]
        public IActionResult UpdateUserRole(UserRole model)
        {

            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            model.UpdatedBy = userSession.UserId;
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("Role/UpdateUserRole?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Role Update Successfully";
                return RedirectToAction("ListUserRole");
            }
            TempData["editError"] = "Failed to Update Role";
            return RedirectToAction("ListUserRole");



        }

        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult DeleteUserRole(string id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            int unprotectedId = int.Parse(_protector.Unprotect(id));
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:5000/api/Role/RemoveUserRole?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);

                TempData["DeleteMenuSuccess"] = "User Id Deleted Successfully";
                return RedirectToAction("ListUserRole");
            }
            TempData["DeleteMenuFaild"] = "Failed To delete User Role";
            return RedirectToAction("ListUserRole");
        }

    }
}
