using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{


    public class AdminController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();
        public AdminController()
        {

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            Console.WriteLine("Add Endpoint Hit");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/GetJobProfile?api-version=1").Result;
            HttpResponseMessage BranchReponse = client.GetAsync(client.BaseAddress + "User/GetBranch?api-version=1").Result;
            HttpResponseMessage RoleReponse = client.GetAsync(client.BaseAddress + "User/GetRole?api-version=1").Result;

            if (response.IsSuccessStatusCode && BranchReponse.IsSuccessStatusCode && RoleReponse.IsSuccessStatusCode)
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
                ViewBag.JobProfileRolelist = JobProfileRolelist;
                ViewBag.branchlist = branchlist;
                ViewBag.Rolelist = Rolelist;



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

            if (ModelState.IsValid)
            {
                model.AddedBy = userSession.UserId;
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "User/RegisterUser?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddUserSuccess"] = "User Created Successfully";
                    return RedirectToAction("ListUsers");
                }
            }
            TempData["AddUserFailed"] = "Faild to Register User";
            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        public IActionResult  UpdateUser(int id)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            EditUserViewModel user = new EditUserViewModel();
            //User/getUser?id=1&api-version=1
            HttpResponseMessage jobProfileresponse = client.GetAsync(client.BaseAddress + "User/GetJobProfile?api-version=1").Result;
            HttpResponseMessage BranchReponse = client.GetAsync(client.BaseAddress + "User/GetBranch?api-version=1").Result;
            HttpResponseMessage RoleReponse = client.GetAsync(client.BaseAddress + "User/GetRole?api-version=1").Result;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"User/getUser?id={id}&api-version=1").Result;
            if (response.IsSuccessStatusCode && jobProfileresponse.IsSuccessStatusCode && BranchReponse.IsSuccessStatusCode && RoleReponse.IsSuccessStatusCode)
            {
                
                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                user = JsonConvert.DeserializeObject<EditUserViewModel>(serres);

                //bind data from database
                var responseData = jobProfileresponse.Content.ReadAsStringAsync().Result;
                var data1 = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data1.Data);
                List<SelectListItem> JobProfileRolelist = new List<SelectListItem>();
                foreach (var item in data1.Data)
                {

                    JobProfileRolelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.id.ToString(), Selected = user.PrimaryJobProfileId==(int)item.id });

                }
                var branchresponseData = BranchReponse.Content.ReadAsStringAsync().Result;

                var branchdata = JsonConvert.DeserializeObject<Response>(branchresponseData);
                Console.WriteLine(branchdata.Data);

                List<SelectListItem> branchlist = new List<SelectListItem>();
                foreach (var item in branchdata.Data)
                {

                    branchlist.Add(new SelectListItem { Text = item.branchName.ToString(), Value = item.id.ToString(), Selected = user.BranchId==(int)item.id });

                }
                var RoleResponseData = RoleReponse.Content.ReadAsStringAsync().Result;
                var Roledata = JsonConvert.DeserializeObject<Response>(RoleResponseData);
                Console.WriteLine(Roledata.Data);
                List<SelectListItem> Rolelist = new List<SelectListItem>();
                foreach (var item in Roledata.Data)
                {

                    Rolelist.Add(new SelectListItem { Text = item.role.ToString(), Value = item.id.ToString(), Selected = user.Role==(int)item.id });

                }
                ViewBag.JobProfileRolelist = JobProfileRolelist;
                ViewBag.branchlist = branchlist;
                ViewBag.Rolelist = Rolelist;

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
            //model.upda = userSession.UserId;
            //EditUserViewModel editmodel = new EditUserViewModel()
            //{
            //    Id=model.Id,
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    Email = model.Email,
            //    JoinDate = model.JoinDate,
            //    BranchId=model.BranchId,
            //    RoleId=model.RoleId,
            //    PrimaryJobProfileId = model.PrimaryJobProfileId,
            //    SecondaryJobProfileId = model.SecondaryJobProfileId,

            //};
            model.UpdatedBy = userSession.UserId;
            string data = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("https://localhost:5000/api/User/UpdateUser?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "User Updated Successfully";
                return RedirectToAction("ListUsers");
            }
            TempData["editError"] = "Failed to Update User";
            return RedirectToAction("ListUsers");



        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            List<UserViewModel> modellist = new List<UserViewModel>(); ;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(responseData);
                ViewBag.UserList = json.data;
                return View();

            }
            return View();
        }

        public IActionResult DeleteUser(int id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
           UserViewModel user = new UserViewModel();
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"User/removeUser?id={id}&api-version=1").Result;
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
                return View();

            }
            return View();
        }



        [HttpPost]
        public IActionResult ListAppraisals(List<AllowAppraisalEditVm> allowAppraisalEditVm)
        {
           
            return View();
        }

    }
}
