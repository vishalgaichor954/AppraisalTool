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
            //List<ReporteeAppraisalDashboard> modellist = new List<ReporteeAppraisalDashboard>();

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/GetReporteeAppraisalByRepAuthority?id={user.UserId} ").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Response>(responseData);


                List<SelectListItem> startDate = new List<SelectListItem>();
                foreach (var item in users.Data)
                {
                    int i = 1;

                    startDate.Add(new SelectListItem { Text =   item.startDate, Value = i.ToString() });
                    i = i + 1;
                }
                ViewBag.startDate = startDate;

                List<SelectListItem> endDate = new List<SelectListItem>();
                foreach (var item in users.Data)
                {
                    int i = 1;

                    endDate.Add(new SelectListItem { Text = item.endDate, Value = i.ToString() });
                    i = i + 1;
                }
                ViewBag.endDate = endDate;

                List<SelectListItem> employeeName = new List<SelectListItem>();
                foreach (var item in users.Data)
                {
                    int i = 1;

                    employeeName.Add(new SelectListItem { Text = item.firstName + item.lastName, Value = i.ToString() });
                    i = i + 1;
                }
                ViewBag.employeeName = employeeName;

                List<SelectListItem> reviewingAuthority = new List<SelectListItem>();
                foreach (var item in users.Data)
                {
                    int i = 1;

                    reviewingAuthority.Add(new SelectListItem { Text = item.revaName, Value = i.ToString() });
                    i = i + 1;
                }
                ViewBag.reviewingAuthority = reviewingAuthority;

                List<SelectListItem> appraisalStatus = new List<SelectListItem>();
                foreach (var item in users.Data)
                {
                    int i = 1;

                    appraisalStatus.Add(new SelectListItem { Text = item.appraisalStatus, Value = i.ToString() });
                    i = i + 1;
                }
                ViewBag.appraisalStatus = appraisalStatus;







                Console.WriteLine(users.Data);
                ViewBag.UserList = users.Data;
                return View();
            }
            return View();
        }
    }
}
