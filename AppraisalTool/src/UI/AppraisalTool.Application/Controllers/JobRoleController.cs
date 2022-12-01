using AppraisalTool.App.Models;
using AppraisalTool.App.Models.JobRoles;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class JobRoleController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();

        public IActionResult AddjobRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddjobRole(JobRoles model)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            
            if (ModelState.IsValid)
            {
                
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Role/AddJobProfileRole?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddUserSuccess"] = "Job Role Added Successfully";
                    return RedirectToAction("ListJobRole");
                }
            }
            TempData["AddUserFailed"] = "Failed to Add Job Role";
            return RedirectToAction("ListJobRole");

        }
        [HttpGet]
        public IActionResult ListJobRole()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;


            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/GetJobProfile?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(responseData);

                ViewBag.JobProfileRole = json.data;
                return View();

            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateJobRole(int id)
        {


            JobRoles financialYear = new JobRoles();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Role/GetJobRoleById?id={id}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                financialYear = JsonConvert.DeserializeObject<JobRoles>(serres);
                //ViewBag.RoleList = menu;

                Console.WriteLine(financialYear);
            }
            return View(financialYear);
        }
        [HttpPost]
        public IActionResult UpdateJobRole(JobRoles model)
        {

            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("Role/UpdateJobProfileRole?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Role Update Successfully";
                return RedirectToAction("ListJobRole");
            }
            TempData["editError"] = "Faild to Update Role";
            return RedirectToAction("ListJobRole");



        }
        public IActionResult DeleteJobRole(int id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:5000/api/Role/RemoveJobProfileRole?id={id}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);

                TempData["DeleteMenuSuccess"] = "Role Id Deleted Successfully";
                return RedirectToAction("ListJobRole");
            }
            TempData["DeleteMenuFaild"] = "Failed To delete Role";
            return RedirectToAction("ListJobRole");
        }
    }
}
