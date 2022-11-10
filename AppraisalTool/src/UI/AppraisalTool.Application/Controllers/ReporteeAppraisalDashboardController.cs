using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.ReporteeAppraisal;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Domain.Common;
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
                List<ReporteeAppraisalListVm> templateData = new List<ReporteeAppraisalListVm>();
                foreach(var i in users.Data)
                {
                    templateData.Add(new ReporteeAppraisalListVm()
                    {
                        StartDate = i.startDate,
                        EndDate = i.endDate,
                        EmployeeId = i.employeeId,
                        FirstName = i.firstName,
                        LastName = i.lastName,
                        RevAuthorityId = i.revAuthorityId,
                        RevaName = i.revaName,
                        AppraisalStatus = i.appraisalStatus,
                        AppraisalStatusId = i.appraisalStatusId,
                        FinancialYearId = i.financialYearId,
                        FinancialStartYear= i.financialStartYear,
                        FinancialEndYear = i.financialEndYear
                    }) ;
                }
                List<SelectListItem> employeeName = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x=>x.EmployeeId))
                {
                    employeeName.Add(new SelectListItem { Text = item.FirstName + item.LastName, Value = item.EmployeeId.ToString() });
                }
                ViewBag.employeeName = employeeName;

                List<SelectListItem> reviewingAuthority = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x=>x.RevAuthorityId))
                {

                    reviewingAuthority.Add(new SelectListItem { Text = item.RevaName, Value = item.RevAuthorityId.ToString() });
                }
                ViewBag.reviewingAuthority = reviewingAuthority;

                List<SelectListItem> appraisalStatus = new List<SelectListItem>();
                foreach (var item in templateData.DistinctBy(x=>x.AppraisalStatusId))
                {
                    {
                        appraisalStatus.Add(new SelectListItem { Text = item.AppraisalStatus, Value = item.AppraisalStatusId.ToString() });
                    }
                }
                ViewBag.appraisalStatus = appraisalStatus;


                if(reporteeAppraisalFilter.PrimaryRole != null)
                {
                    
                }

                if (reporteeAppraisalFilter.StartDate != null)
                {
                    templateData = templateData.FindAll(x => {
                        DateTime? current = Convert.ToDateTime(x.StartDate).Date;
                        DateTime filterDate = Convert.ToDateTime(reporteeAppraisalFilter.StartDate).Date;
                        return current.Equals(filterDate);
                        });
                }

                if (reporteeAppraisalFilter.EndDate != null)
                {
                    templateData = templateData.FindAll(x => {
                        DateTime? current = Convert.ToDateTime(x.EndDate).Date;
                        DateTime filterDate = Convert.ToDateTime(reporteeAppraisalFilter.EndDate).Date;
                        return current.Equals(filterDate);
                    });
                }

                if (reporteeAppraisalFilter.EmployeeName != null)
                {
                    templateData = templateData.FindAll(x => x.EmployeeId == reporteeAppraisalFilter.EmployeeName);
                }

                if (reporteeAppraisalFilter.ReviewingAuthority != null)
                {
                    templateData = templateData.FindAll(x => x.RevAuthorityId == reporteeAppraisalFilter.ReviewingAuthority);
                }

                if (reporteeAppraisalFilter.Status != null)
                {
                    templateData = templateData.FindAll(x => x.AppraisalStatusId == reporteeAppraisalFilter.Status);
                }

                ViewBag.UserList = templateData;
                return View();
            }
            return View();
        }
    }
}
