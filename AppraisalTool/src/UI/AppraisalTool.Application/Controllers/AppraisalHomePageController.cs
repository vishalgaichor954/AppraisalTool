using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.SelfAppraisal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using AppraisalTool.App.Models.Navbar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.ComponentModel;
using System.Reflection;

namespace AppraisalTool.App.Controllers
{

    public class AppraisalHomePageController : Controller
    {
        private readonly ILogger<AppraisalHomePageController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v1");
        HttpClient client;
        public AppraisalHomePageController(ILogger<AppraisalHomePageController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        //Uri baseAddress = new Uri("https://localhost:5000/api");

        public IActionResult HomePageAppraisal()
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            SelfAppraisalHome model = new SelfAppraisalHome();
            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome?userId={user.UserId}").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data.Data);
                List<SelfAppraisalHome> mylist = JsonConvert.DeserializeObject<List<SelfAppraisalHome>>(JsonConvert.SerializeObject(data.Data));
                List<SelectListItem> financialYearList = new List<SelectListItem>();
                foreach (var item in data.Data)
                {

                    financialYearList.Add(new SelectListItem { Text ="FY" + item.startYear.ToString()+"-"+item.endYear.ToString(), Value = item.id.ToString() });

                }
                ViewBag.financialYearList = financialYearList;
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);
                ViewBag.AppraisalsToBeFilled = data.Data[0].appraisalsToBeFilled;
                ViewBag.PendingAppraisals = data.Data[0].pendingAppraisals;
                ViewBag.LastDate = data.Data[0].lastDate;


                ForgetPasswordResponse AuthData = JsonConvert.DeserializeObject<ForgetPasswordResponse>(response);
                dynamic res = JsonConvert.SerializeObject(AuthData.Data);
                var selfappraisal = JsonConvert.DeserializeObject<List<SelfAppraisalHome>>(res);
               
                 SessionHelper.SetObjectAsJson(HttpContext.Session, "year", selfappraisal);
               
                
                return View();

                ViewBag.UserId = user.UserId;
                ViewBag.UserRole = user.Role;
                //ViewBag.FinanceId = user.FinancialYearId;
            }
            return View();

        }
        public IActionResult SelfAppraisalDashboard()
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/byYear?userId={user.UserId}").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data.Data);
                
                ViewBag.ReportingAuthorityFirstName = data.Data[0].reportingAuthorityFirstName;
                Console.WriteLine(ViewBag.ReportingAuthorityFirstName);
                ViewBag.ReviewingAuthorityFirstName = data.Data[0].reviewingAuthorityFirstName;
                Console.WriteLine(ViewBag.ReviewingAuthorityFirstName);
                ViewBag.Role = data.Data[0].role;
                ViewBag.AppraisalStatus = data.Data[0].appraisalStatus;
                ViewBag.Date = data.Data[0].date;
                ViewBag.ReviewingAuthorityLastName = data.Data[0].reviewingAuthorityLastName;
                ViewBag.ReportingAuthorityLastName = data.Data[0].reportingAuthorityLastName;





                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);

                return View();
            }
            return View();

        }

        //public IActionResult AddSelfAppraisal()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = baseAddress;
        //    HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"/v1/Metric/GetAllListOfMetric").Result;
        //    if (cardResponse.IsSuccessStatusCode)
        //    {
        //        var responseData = cardResponse.Content.ReadAsStringAsync().Result;
        //        var res = JsonConvert.DeserializeObject<Response>(responseData);

        //        List<MetricsDto> mylist = JsonConvert.DeserializeObject<List<MetricsDto>>(JsonConvert.SerializeObject(res.Data));

        //        List<MetricsDto> IMetric = new List<MetricsDto>();
        //        List<MetricsDto> BevMetric = new List<MetricsDto>();
        //        List<MetricsDto> JobMetric = new List<MetricsDto>();

        //        mylist.ForEach(item =>
        //        {
        //            if (item.List_Id.Equals(1))
        //            {
        //                IMetric.Add(item);
        //            }
        //            else if (item.List_Id.Equals(3))
        //            {
        //                BevMetric.Add(item);
        //            }
        //            else if (item.List_Id.Equals(4))
        //            {
        //                JobMetric.Add(item);
        //            }
        //        });


        //        SelfAppraisalMetricsModel model = new SelfAppraisalMetricsModel() { IMetric = IMetric, BevMetric = BevMetric, JobMetric = JobMetric };
        //        Console.Write(model);
        //        ViewBag.AppraisalFormModel = model;
        //        return View();
        //    }
        //    return View();

        //}

        //[HttpPost]
        //public IActionResult AddSelfAppraisal(IEnumerable<ScoreModel> scores)
        //{
        //    return RedirectToAction("AddSelfAppraisal");
        //}

        public IActionResult AddSelfAppraisal()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"/v1/Metric/GetAllListOfMetric").Result;
            if (cardResponse.IsSuccessStatusCode)
            {
                var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<MetricsDto> mylist = JsonConvert.DeserializeObject<List<MetricsDto>>(JsonConvert.SerializeObject(res.Data));

                List<MetricsDto> IMetric = new List<MetricsDto>();
                List<MetricsDto> BevMetric = new List<MetricsDto>();
                List<MetricsDto> JobMetric = new List<MetricsDto>();

                mylist.ForEach(item =>
                {
                    if (item.List_Id.Equals(1))
                    {
                        IMetric.Add(item);
                    }
                    else if (item.List_Id.Equals(3))
                    {
                        BevMetric.Add(item);
                    }
                    else if (item.List_Id.Equals(4))
                    {
                        JobMetric.Add(item);
                    }
                });


                SelfAppraisalMetricsModel model = new SelfAppraisalMetricsModel() { IMetric = IMetric, BevMetric = BevMetric, JobMetric = JobMetric };
                Console.Write(model);
                ViewBag.AppraisalFormModel = model;
                //[] bindingModel = new MetricsDto[mylist.Count()];
                return View(mylist);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddSelfAppraisal(List<MetricsDto> scores )
        {
            return RedirectToAction("AddSelfAppraisal");
        }
    }

}
