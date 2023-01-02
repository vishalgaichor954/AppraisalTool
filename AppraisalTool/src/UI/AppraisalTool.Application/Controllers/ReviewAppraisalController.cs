using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Services.CustomAttributes;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AppraisalTool.App.Controllers
{
    public class ReviewAppraisalController : Controller
    {
        private readonly ILogger<ReviewAppraisalController> _logger;
        Uri baseAddress;
        HttpClient client;
        public ReviewAppraisalController(ILogger<ReviewAppraisalController> logger, IConfiguration configuration)
        {
            client = new HttpClient();
            baseAddress = new Uri(configuration.GetValue<string>("BaseUrl"));
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        [RouteAccess(Roles = "ADMINISTRATOR,REVIEWING AUTHORITY")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RouteAccess(Roles = "ADMINISTRATOR,REVIEWING AUTHORITY")]
        public IActionResult ReviewAppraisalDashboard(ReviewAppraisalFilter? reviewAppraisalFilter)
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            Console.WriteLine("ReviewAppraisalDashboard");
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"v1/AppraisalHome/GetReviewAppraisalByRevAuthority?id={user.UserId} ").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Response>(responseData);


                List<ReviewAppraisalListVm> templateData = new List<ReviewAppraisalListVm>();
                foreach (var i in users.Data)
                {
                    templateData.Add(new ReviewAppraisalListVm()
                    {
                        AppraisalId = i.appraisalId,
                        StartDate = i.startDate,
                        EndDate = i.endDate,
                        EmployeeId = i.employeeId,
                        FirstName = i.firstName,
                        LastName = i.lastName,
                        RepAuthorityId = i.repAuthorityId,
                        RepaName = i.repaName,
                        AppraisalStatus = i.appraisalStatus,
                        AppraisalStatusId = i.appraisalStatusId,
                        FinancialYearId = i.financialYearId,
                        FinancialStartYear = i.financialStartYear,
                        FinancialEndYear = i.financialEndYear
                    });
                }
                List<SelectListItem> employeeName = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x => x.EmployeeId))
                {
                    employeeName.Add(new SelectListItem { Text = item.FirstName + item.LastName, Value = item.EmployeeId.ToString() });
                }
                ViewBag.employeeName = employeeName;

                List<SelectListItem> reportingAuthority = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x => x.RepAuthorityId))
                {

                    reportingAuthority.Add(new SelectListItem { Text = item.RepaName, Value = item.RepAuthorityId.ToString() });
                }
                ViewBag.reportingAuthority = reportingAuthority;

                List<SelectListItem> appraisalStatus = new List<SelectListItem>();
                foreach (var item in templateData.Where(x => x.AppraisalStatusId != 2).DistinctBy(x => x.AppraisalStatusId))
                {
                    {
                        appraisalStatus.Add(new SelectListItem { Text = item.AppraisalStatus, Value = item.AppraisalStatusId.ToString() });
                    }
                }
                ViewBag.appraisalStatus = appraisalStatus;


                if (reviewAppraisalFilter.PrimaryRole != null)
                {

                }

                if (reviewAppraisalFilter.StartDate != null)
                {
                    templateData = templateData.FindAll(x => {
                        DateTime? current = Convert.ToDateTime(x.StartDate).Date;
                        DateTime filterDate = Convert.ToDateTime(reviewAppraisalFilter.StartDate).Date;
                        return current.Equals(filterDate);
                    });
                }

                if (reviewAppraisalFilter.EndDate != null)
                {
                    templateData = templateData.FindAll(x => {
                        DateTime? current = Convert.ToDateTime(x.EndDate).Date;
                        DateTime filterDate = Convert.ToDateTime(reviewAppraisalFilter.EndDate).Date;
                        return current.Equals(filterDate);
                    });
                }

                if (reviewAppraisalFilter.EmployeeName != null)
                {
                    templateData = templateData.FindAll(x => x.EmployeeId == reviewAppraisalFilter.EmployeeName);
                }

                if (reviewAppraisalFilter.ReportingAuthority != null)
                {
                    templateData = templateData.FindAll(x => x.RepAuthorityId == reviewAppraisalFilter.ReportingAuthority);
                }

                if (reviewAppraisalFilter.Status != null)
                {
                    templateData = templateData.FindAll(x => x.AppraisalStatusId == reviewAppraisalFilter.Status);
                }
                //templateData.Reverse();
                ViewBag.UserList = templateData;
                return View();
            }
            return View();
        }

        [RouteAccess(Roles = "ADMINISTRATOR,REVIEWING AUTHORITY")]
        public IActionResult ReviewAppraisalDashboard()
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            Console.WriteLine("ReviewAppraisalDashboard");
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"v1/AppraisalHome/GetReviewAppraisalByRevAuthority?id={user.UserId} ").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Response>(responseData);


                List<ReviewAppraisalListVm> templateData = new List<ReviewAppraisalListVm>();
                foreach (var i in users.Data)
                {
                    templateData.Add(new ReviewAppraisalListVm()
                    {
                        
                        AppraisalId = i.appraisalId,
                        StartDate = i.startDate,
                        EndDate = i.endDate,
                        EmployeeId = i.employeeId,
                        FirstName = i.firstName,
                        LastName = i.lastName,
                        RepAuthorityId = i.repAuthorityId,
                        RepaName = i.repaName,
                        AppraisalStatus = i.appraisalStatus,
                        AppraisalStatusId = i.appraisalStatusId,
                        FinancialYearId = i.financialYearId,
                        FinancialStartYear = i.financialStartYear,
                        FinancialEndYear = i.financialEndYear
                    });
                }
                List<SelectListItem> employeeName = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x => x.EmployeeId))
                {
                    employeeName.Add(new SelectListItem { Text = item.FirstName + item.LastName, Value = item.EmployeeId.ToString() });
                }
                ViewBag.employeeName = employeeName;

                List<SelectListItem> reportingAuthority = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x => x.RepAuthorityId))
                {

                    reportingAuthority.Add(new SelectListItem { Text = item.RepaName, Value = item.RepAuthorityId.ToString() });
                }
                ViewBag.reportingAuthority = reportingAuthority;

                List<SelectListItem> appraisalStatus = new List<SelectListItem>();
                foreach (var item in templateData.Where(x=> x.AppraisalStatusId != 2).DistinctBy(x => x.AppraisalStatusId))
                {
                    {
                        appraisalStatus.Add(new SelectListItem { Text = item.AppraisalStatus, Value = item.AppraisalStatusId.ToString() });
                    }
                }
                ViewBag.appraisalStatus = appraisalStatus;
               
                //templateData.Reverse();
                
                ViewBag.UserList = templateData;
                return View();
            }
            return View();
        }

    }
}

