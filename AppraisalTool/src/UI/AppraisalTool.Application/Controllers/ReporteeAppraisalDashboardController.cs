using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.ReporteeAppraisal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AppraisalTool.App.Controllers
{
    public class ReporteeAppraisalDashboardController : Controller
    {

        private readonly ILogger<ReporteeAppraisalDashboardController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v1");
        HttpClient client;
        public ReporteeAppraisalDashboardController(ILogger<ReporteeAppraisalDashboardController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ReporteeAppraisalDashboard()
        {
            Console.WriteLine("ReporteeAppraisalDashboard");
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            List<ReporteeAppraisalDashboard> modellist = new List<ReporteeAppraisalDashboard>();

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $" ").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Response>(responseData);
                List<SelectListItem> financialYearList = new List<SelectListItem>();
                foreach (var item in users.Data)
                {

                    financialYearList.Add(new SelectListItem { Text = "FY" + item.startDate.ToString() + "-" + item.endDate.ToString(), Value = item.id.ToString() });

                }
                ViewBag.financialYearList = financialYearList;
                Console.WriteLine(users.Data);
                ViewBag.UserList = users.Data;
                return View();
            }
            return View();
        }
    }
}
