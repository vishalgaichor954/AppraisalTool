using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.FinancialYear;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class FinancialYearController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();

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

            if (ModelState.IsValid)
            {
                model.AddedBy = userSession.UserId;
                model.IsActive = Convert.ToBoolean(status);
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "FinancialYear/AddFinancialYear?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddUserSuccess"] = "Financial Year Added Successfully";
                    return RedirectToAction("ListFinancialYear");
                }
            }
            TempData["AddUserFailed"] = "Faild to Add Finaincial Year";
            return RedirectToAction("ListFinancialYear");

        }
        [HttpGet]
        public IActionResult ListFinancialYear()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;


            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "FinancialYear/ListFinancialYear?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(responseData);
                ViewBag.FinancialYearList = json.data;
                return View();

            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateYear(int id)
        {


            FinancialYear financialYear = new FinancialYear();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"FinancialYear/GetFinancialYearById?id={id}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                financialYear = JsonConvert.DeserializeObject<FinancialYear>(serres);
                //ViewBag.RoleList = menu;

                Console.WriteLine(financialYear);
            }
            return View(financialYear);
        }
        [HttpPost]
        public IActionResult UpdateYear(FinancialYear model)
        {

            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            model.UpdatedBy = userSession.UserId;
            string data = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("FinancialYear/UpdateFinanacialYear?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Financial Year Update Successfully";
                return RedirectToAction("ListFinancialYear");
            }
            TempData["editError"] = "Faild to Financial Year";
            return RedirectToAction("ListFinancialYear");



        }
        public IActionResult DeleteYear(int id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"FinancialYear/removeFinancialYear?id={id}api-version=1").Result;
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
        public IActionResult ListAppraisal()
        {
            return View();
        }
    }
}
