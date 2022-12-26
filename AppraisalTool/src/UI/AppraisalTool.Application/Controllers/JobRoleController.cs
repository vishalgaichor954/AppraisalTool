using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.JobRoles;
using AppraisalTool.App.Services.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class JobRoleController : Controller
    {
        Uri baseAddress;
        HttpClient client = new HttpClient();
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;

        public JobRoleController(IMapper mapper, IDataProtectionProvider provider, IConfiguration configuration)
        {
            baseAddress = new Uri(configuration.GetValue<string>("BaseUrl"));
            _mapper = mapper;
            _protector = provider.CreateProtector("");
        }

        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult AddjobRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddjobRole(JobRoles model)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            if (ModelState.IsValid)
            {
                var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
                model.AddedBy = userSession.UserId;
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
        [RouteAccess(Roles = "ADMINISTRATOR,REPORTING AUTHORITY,REVIEWING AUTHORITY,EMPLOYEE")]
        public IActionResult ListJobRole()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;


            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/GetJobProfile?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<JobRoles> mylist = JsonConvert.DeserializeObject<List<JobRoles>>(JsonConvert.SerializeObject(res.Data));
                //dynamic json = JsonConvert.DeserializeObject(responseData);

                ViewBag.JobProfileRole = _mapper.Map<IEnumerable<jobRolesEncoded>>(mylist);
                return View();

            }
            return View();
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR,REPORTING AUTHORITY,REVIEWING AUTHORITY,EMPLOYEE")]
        public IActionResult UpdateJobRole(string id)
        {


            JobRoles financialYear = new JobRoles();
            client = new HttpClient();
            client.BaseAddress = baseAddress;

            int unprotectedId = 0;
            try
            {
                unprotectedId = int.Parse(_protector.Unprotect(id));
            }
            catch (Exception e)
            {
                return RedirectToAction("ListJobRole", "JobRole");
            }

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Role/GetJobRoleById?id={unprotectedId}&api-version=1").Result;
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
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            model.UpdatedBy = userSession.UserId;
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseAddress + "Role/UpdateJobProfileRole?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Role Update Successfully";
                return RedirectToAction("ListJobRole");
            }
            TempData["editError"] = "Faild to Update Role";
            return RedirectToAction("ListJobRole");



        }

        [RouteAccess(Roles = "ADMINISTRATOR,REPORTING AUTHORITY,REVIEWING AUTHORITY,EMPLOYEE")]
        public IActionResult DeleteJobRole(string id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            int unprotectedId = int.Parse(_protector.Unprotect(id));

            HttpResponseMessage response = client.DeleteAsync(baseAddress + $"Role/RemoveJobProfileRole?id={unprotectedId}&api-version=1").Result;
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
