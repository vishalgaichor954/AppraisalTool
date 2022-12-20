using AppraisalTool.App.Dtos;
using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.FinancialYear;
using AppraisalTool.App.Models.Menu;
using AppraisalTool.App.Services.CustomAttributes;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class FinancialYearController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();

        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public FinancialYearController(IMapper mapper, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _protector = provider.CreateProtector("");
        }

        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult AddFinancialYear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFinancialYear(FinancialYear model, bool status)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            ModelState.Remove("StartYear");
            ModelState.Remove("EndYear");
            if (ModelState.IsValid)
            {
                model.AddedBy = userSession.UserId;
                model.IsActive = Convert.ToBoolean(status);
                string startDate = model.StartDate.ToString();
                string endDate = model.EndDate.ToString();
                string startyear = DateTime.Parse(model.StartDate.ToString()).Year.ToString();
                string endyear = DateTime.Parse(model.EndDate.ToString()).Year.ToString();
                model.StartYear = Int32.Parse(startyear);
                model.EndYear = Int32.Parse(endyear);
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "FinancialYear/AddFinancialYear?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddUserSuccess"] = "Financial Year Added Successfully";
                    return RedirectToAction("ListFinancialYear");
                }
            }
            TempData["AddUserFailed"] = "Failed to Add Finaincial Year";
            return RedirectToAction("ListFinancialYear");
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ListFinancialYear()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "FinancialYear/ListFinancialYear?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<FinancialYear> mylist = JsonConvert.DeserializeObject<List<FinancialYear>>(JsonConvert.SerializeObject(res.Data));
                ViewBag.FinancialYearList = _mapper.Map<IEnumerable<FinancialYearEncodeDto>>(mylist);
                return View();
            }
            return View();
        }

        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult UpdateYear(string id)
        {
            int unprotectedId = 0;

            try
            {
                unprotectedId = int.Parse(_protector.Unprotect(id));
            }
            catch (Exception e)
            {
                return RedirectToAction("ListFinancialYear", "FinancialYear");
            }

            FinancialYear financialYear = new FinancialYear();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"FinancialYear/GetFinancialYearById?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                financialYear = JsonConvert.DeserializeObject<FinancialYear>(serres);
                financialYear.Id = unprotectedId;
                //ViewBag.RoleList = menu;
            }
            return View(financialYear);
        }

        [HttpPost]
        public IActionResult UpdateYear(FinancialYear model, bool status, int id)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            model.Id = id;
            model.UpdatedBy = userSession.UserId;
            model.IsActive = status;
            string startDate = model.StartDate.ToString();
            string endDate = model.EndDate.ToString();
            string startyear = DateTime.Parse(model.StartDate.ToString()).Year.ToString();
            string endyear = DateTime.Parse(model.EndDate.ToString()).Year.ToString();
            model.StartYear = Int32.Parse(startyear);
            model.EndYear = Int32.Parse(endyear);
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("FinancialYear/UpdateFinanacialYear?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Financial Year Updated Successfully";
                return RedirectToAction("ListFinancialYear");
            }
            TempData["editError"] = "Failed to Update Financial Year";
            return RedirectToAction("ListFinancialYear");
        }

        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult DeleteYear(string id)
        {
            int unprotectedId = int.Parse(_protector.Unprotect(id));
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:5000/api/FinancialYear/removeFinancialYear?id={unprotectedId}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);
                TempData["DeleteMenuSuccess"] = "FinancialYear Id Deleted Successfully";
                return RedirectToAction("ListFinancialYear");
            }
            TempData["DeleteMenuFaild"] = "Menu to Delete User";
            return RedirectToAction("ListFinancialYear");
        }



        [HttpGet]
        [RouteAccess(Roles = "ADMINISTRATOR")]
        public IActionResult ListAppraisal()
        {
            return View();
        }
    }
}

