using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.Branches;
using AppraisalTool.App.Services.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{

    public class BranchController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;

        public BranchController(IMapper mapper, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _protector = provider.CreateProtector("");
        }
        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ListBranches()
        {

            Uri baseAddress = new Uri("https://localhost:5000/api/");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/ListOfBranch?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseBranch = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseBranch);

                List<BranchVm> mylist = JsonConvert.DeserializeObject<List<BranchVm>>(JsonConvert.SerializeObject(res.Data));

                ViewBag.BranchList = _mapper.Map<IEnumerable<EncodedBranchDto>>(mylist); 
                return View();

            }
            return View();
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult AddBranch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBranch(BranchVm model)
        {

            Uri baseAddress = new Uri("https://localhost:5000/api/");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            if (ModelState.IsValid)
            {
                model.AddedBy = userSession.UserId;
                //model.IsActive = Convert.ToBoolean(status);

                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "User/AddBranch?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddBranchSuccess"] = "Branch Added Successfully";
                    return RedirectToAction("ListBranches");
                }
            }
            TempData["AddBranchFailed"] = "Failed to Add Branch";
            return RedirectToAction("ListBranches");

        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult UpdateBranch(string id)
        {
            Uri baseAddress = new Uri("https://localhost:5000/api/");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            int unprotectedId = int.Parse(_protector.Unprotect(id));
            BranchVm branchVm = new BranchVm();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"User/GetBranchById?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                branchVm = JsonConvert.DeserializeObject<BranchVm>(data);
            }
            return View(branchVm);
        }

        [HttpPost]
        public IActionResult UpdateBranch(BranchVm model)
        {
            Uri baseAddress = new Uri("https://localhost:5000/api/");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            model.UpdatedBy = userSession.UserId;
            //model.IsActive = status;
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("User/UpdateBranch?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessBranch"] = "Branch Updated Successfully";
                return RedirectToAction("ListBranches");
            }
            TempData["BranchError"] = "Failed To Update Branch";
            return RedirectToAction("ListBranches");
        }

        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult DeleteBranch(string id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            Uri baseAddress = new Uri("https://localhost:5000/api/");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            int unprotectedId = int.Parse(_protector.Unprotect(id));
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:5000/api/User/RemoveBranch?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);

                TempData["DeleteMenuSuccess"] = "User Id Deleted Successfully";
                return RedirectToAction("ListBranches");
            }
            TempData["DeleteMenuFaild"] = "Failed To delete User Role";
            return RedirectToAction("ListBranches");
        }

    }
}
