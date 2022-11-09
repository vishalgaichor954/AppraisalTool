using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.ReporteeAppraisal;
using AppraisalTool.Application.Models.AppraisalTool;
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


        public IActionResult ReporteeAppraisalDashboard( ReporteeAppraisalFilter? reporteeAppraisalFilter)
        {
            Console.WriteLine("ReporteeAppraisalDashboard");
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //List<ReporteeAppraisalDashboard> modellist = new List<ReporteeAppraisalDashboard>();

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/GetReporteeAppraisalByRepAuthority?id={user.UserId} ").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Response>(responseData);


                //List<SelectListItem> startDate = new List<SelectListItem>();
                //foreach (var item in users.Data)
                //{

                //    startDate.Add(new SelectListItem { Text = item.startDate, Value = item.startDate });
                //}
                //ViewBag.startDate = startDate;

                //List<SelectListItem> endDate = new List<SelectListItem>();
                //foreach (var item in users.Data)
                //{

                //    endDate.Add(new SelectListItem { Text = item.endDate, Value = item.endDate });
                //}
                //ViewBag.endDate = endDate;

                List<SelectListItem> employeeName = new List<SelectListItem>();
                foreach (var item in users.Data)
                {

                    employeeName.Add(new SelectListItem { Text = item.firstName + item.lastName, Value = item.employeeId });

                }
                ViewBag.employeeName = employeeName;

                List<SelectListItem> reviewingAuthority = new List<SelectListItem>();
                foreach (var item in users.Data)
                {

                    reviewingAuthority.Add(new SelectListItem { Text = item.revaName, Value = item.revAuthorityId });
                }
                ViewBag.reviewingAuthority = reviewingAuthority;

                List<SelectListItem> appraisalStatus = new List<SelectListItem>();
                foreach (var item in users.Data)
                {

                    {

                        appraisalStatus.Add(new SelectListItem { Text = item.appraisalStatus, Value = item.appraisalStatusId });
                    }
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
