using AppraisalTool.App.Models;
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

            client = new HttpClient();
            client.BaseAddress = baseAddress;
            Console.WriteLine("PostMethod hit");
            if (ModelState.IsValid)
            {

            }
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "User/RegisterUser?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CreateUser");
            }
            TempData["Error"] = "Faild to Register User";
            return RedirectToAction("CreateUser");






        }
        //[HttpGet]
        //public IActionResult GetRoles()
        //{
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User?api-version=1").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseData = response.Content.ReadAsStringAsync().Result;
        //        Console.WriteLine(responseData);
        //        return RedirectToAction("");
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

        [HttpGet]
        public IActionResult GetAllUserList()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            List<UserViewModel> modellist = new List<UserViewModel>(); ;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(responseData);
                Console.WriteLine(responseData);
                //modellist = JsonConvert.DeserializeObject<List<UserViewModel>>(json.data[0]);
                ViewBag.Firstname=json.firstname;
                ViewBag.LastName = json.lastName;
                ViewBag.Email=json.email;
                ViewBag.BranchName=json.branchName;
                ViewBag.JoinDate = json.joinDate;
                ViewBag.LastAppraisalDate=json.lastAppraisalDate;
                return View();

            }
            return View();


        }
    }
}
