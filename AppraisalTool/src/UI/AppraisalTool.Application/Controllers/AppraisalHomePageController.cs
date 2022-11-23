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
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using AppraisalTool.Domain.Entities;
using System.Security.Cryptography;

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
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            SelfAppraisalHome model = new SelfAppraisalHome();
            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome?userId={user.UserId}").Result;
            HttpResponseMessage cardResponse = client.GetAsync($"https://localhost:5000/api/User/GetAllCard?id={user.RoleId}&api-version=1").Result;
            HttpResponseMessage reportResponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetReporteeAppraisalByRepAuthority?id={user.UserId}").Result;
            HttpResponseMessage reviewResponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetReviewAppraisalByRevAuthority?id={user.UserId}").Result;
            HttpResponseMessage yearResponse = client.GetAsync($"https://localhost:5000/api/v1/FinancialYear/GetFinancialYearsByUserJoining?userId={user.UserId}").Result;


            if (httpResponseMessage.IsSuccessStatusCode && cardResponse.IsSuccessStatusCode && reportResponse.IsSuccessStatusCode && reviewResponse.IsSuccessStatusCode && yearResponse.IsSuccessStatusCode)
            {
                int reporteeCompleted = 0;
                int reporteeCount = 0;
                int reviewCount = 0;
                var responseData = reportResponse.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(users.Data);
                foreach (var item in users.Data)
                {


                    if (item.status == 2)
                    {
                        reporteeCount = reporteeCount + 1;
                    }
                    if(item.status == 3)
                    {
                        reporteeCompleted= reporteeCompleted+1;
                    }

                }
                ViewBag.PendingAtReportee = reporteeCount;
                ViewBag.ReporteeCompleted = reporteeCompleted;


                var reviewData = reviewResponse.Content.ReadAsStringAsync().Result;
                var employees = JsonConvert.DeserializeObject<Response>(reviewData);
                Console.WriteLine(employees.Data);

                foreach(var item in employees.Data)
                    {
                    if (item.status == 3)
                    {
                        reviewCount = reviewCount + 1;
                    }


                }
                
                ViewBag.PendingAtReview = reviewCount;


                var CardresponseData = cardResponse.Content.ReadAsStringAsync().Result;
                //var Cardres = JsonConvert.DeserializeObject<ForgetPasswordResponse>(CardresponseData);
                dynamic json = JsonConvert.DeserializeObject(CardresponseData);
                ViewBag.GetMenuCards = json.data;
                Console.WriteLine(ViewBag.GetMenuCards);
                var menuData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var menuResponseData= JsonConvert.DeserializeObject<Response>(menuData);
                var resAppraisalData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var yearResponseData = yearResponse.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(resAppraisalData);
                Console.WriteLine(data.Data);
                //List<SelfAppraisalHome> mylist = JsonConvert.DeserializeObject<List<SelfAppraisalHome>>(JsonConvert.SerializeObject(data.Data));
                List<FinancialYear> yearResponseList = JsonConvert.DeserializeObject<List<FinancialYear>>(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<Response>(yearResponseData).Data));

                List<SelectListItem> financialYearList = new List<SelectListItem>();
                foreach (var item in yearResponseList)
                {

                    financialYearList.Add(new SelectListItem { Text = "FY" + item.StartYear.ToString() + "-" + item.EndYear.ToString(), Value = item.Id.ToString(), Selected = true });


                }
                financialYearList.Add(new SelectListItem { Text = "FY2022-2023", Value = "4" });

                ViewBag.financialYearList = financialYearList.DistinctBy(x => x.Value);
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);

                //HardCoded Values
                try
                {
                    ViewBag.AppraisalsToBeFilled = menuResponseData.Data[0].appraisalsToBeFilled;
                    ViewBag.PendingAppraisals = menuResponseData.Data[0].pendingAppraisals;
                    ViewBag.LastDate = menuResponseData.Data[0].lastDate;
                    ViewBag.CurrentYear = menuResponseData.Data[0].currentYear;
                }
                catch (Exception e)
                {

                    ViewBag.PendingAppraisals = 1;
                    ViewBag.LastDate = "31st March 2023";
                }

                ForgetPasswordResponse AuthData = JsonConvert.DeserializeObject<ForgetPasswordResponse>(response);
                dynamic res = JsonConvert.SerializeObject(AuthData.Data);
                var selfappraisal = JsonConvert.DeserializeObject<List<SelfAppraisalHome>>(res);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "year", selfappraisal);


                return View();
            }
            return View();

        }
        public IActionResult SelfAppraisalDashboard(int? Fid, string? Fyear)
        {

            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Fid == null || Fyear == null)
            {
                return RedirectToAction("HomePageAppraisal","AppraisalHomePage");
            }

            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/byYear?userId={user.UserId}").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data.Data);
                if(data.Data!=null )
                {
                    foreach(var item in data.Data)
                    {
                        if(Convert.ToInt32(item.financialYearId)== Fid)
                        {
                            ViewBag.fyear = Fyear;
                            ViewBag.Fid = Fid;
                            ViewBag.ReportingAuthorityFirstName = item.reportingAuthorityFirstName;
                            Console.WriteLine(ViewBag.ReportingAuthorityFirstName);
                            ViewBag.ReviewingAuthorityFirstName = item.reviewingAuthorityFirstName;
                            Console.WriteLine(ViewBag.ReviewingAuthorityFirstName);
                            ViewBag.Role = item.role;
                            ViewBag.AppraisalStatus = item.appraisalStatus;
                            ViewBag.Date = item.date;
                            ViewBag.ReviewingAuthorityLastName = item.reviewingAuthorityLastName;
                            ViewBag.ReportingAuthorityLastName = item.reportingAuthorityLastName;
                        }
                        else
                        {
                            ViewBag.ReportingAuthorityFirstName = item.reportingAuthorityFirstName;
                            Console.WriteLine(ViewBag.ReportingAuthorityFirstName);
                            ViewBag.ReviewingAuthorityFirstName = item.reviewingAuthorityFirstName;
                            Console.WriteLine(ViewBag.ReviewingAuthorityFirstName);
                            ViewBag.Role = item.role;
                            ViewBag.AppraisalStatus = "-";
                            ViewBag.Date = item.date;
                            ViewBag.ReviewingAuthorityLastName = item.reviewingAuthorityLastName;
                            ViewBag.ReportingAuthorityLastName = item.reportingAuthorityLastName;
                        }

                    }
                }
                else
                {
                    ViewBag.ReportingAuthorityFirstName = "Not Assigned";
                    ViewBag.ReviewingAuthorityFirstName = "Not Assigned";
                    ViewBag.Date = "-";
                }
                //try
                //{
                //    ViewBag.fyear = Fyear;
                //    ViewBag.Fid = Fid;
                //    ViewBag.ReportingAuthorityFirstName = data.Data[0].reportingAuthorityFirstName;
                //    Console.WriteLine(ViewBag.ReportingAuthorityFirstName);
                //    ViewBag.ReviewingAuthorityFirstName = data.Data[0].reviewingAuthorityFirstName;
                //    Console.WriteLine(ViewBag.ReviewingAuthorityFirstName);
                //    ViewBag.Role = data.Data[0].role;
                //    ViewBag.AppraisalStatus = data.Data[0].appraisalStatus;
                //    ViewBag.Date = data.Data[0].date;
                //    ViewBag.ReviewingAuthorityLastName = data.Data[0].reviewingAuthorityLastName;
                //    ViewBag.ReportingAuthorityLastName = data.Data[0].reportingAuthorityLastName;
                //}
                //catch (Exception e)
                //{
                //    ViewBag.ReportingAuthorityFirstName = "Not Assigned";
                //    ViewBag.ReviewingAuthorityFirstName = "Not Assigned";
                //    ViewBag.Date = "1st April 2022-31st March 2023";
                //}
                //string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(response);

                return View();
            }
            return View();

        }

        [HttpGet]
        public IActionResult AddReportingAuthorityAppraisal(int? Appraisald)
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Appraisald == null)
            {
                return RedirectToAction("ReporteeAppraisalDashboard", "ReporteeAppraisalDashboard");
            }

            ///AppraisalHome/GetAppraisalResultsByAppraisalId?id=40
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"/AppraisalHome/GetAppraisalResultsByAppraisalId?id={Appraisald}").Result;
            if (cardResponse.IsSuccessStatusCode)
            {

                var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<ReportingMetricDto> mylist = JsonConvert.DeserializeObject<List<ReportingMetricDto>>(JsonConvert.SerializeObject(res.Data));

                //List<MetricsDto> IMetric = n
                //ew List<MetricsDto>();
                //List<MetricsDto> BevMetric = new List<MetricsDto>();
                //List<MetricsDto> JobMetric = new List<MetricsDto>();

                //mylist.ForEach(item =>
                //{
                //    if (item.List_Id.Equals(1))
                //    {
                //        IMetric.Add(item);
                //    }
                //    else if (item.List_Id.Equals(3))
                //    {
                //        BevMetric.Add(item);
                //    }
                //    else if (item.List_Id.Equals(4))
                //    {
                //        JobMetric.Add(item);
                //    }
                //});


                //SelfAppraisalMetricsModel model = new SelfAppraisalMetricsModel() { IMetric = IMetric, BevMetric = BevMetric, JobMetric = JobMetric };
                //Console.Write(model);
                //ViewBag.AppraisalFormModel = model;
                //[] bindingModel = new MetricsDto[mylist.Count()];
                return View(mylist);
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddReportingAuthorityAppraisal(List<ReportingMetricDto> scores)
        {
            Console.WriteLine(scores);

            foreach (var item in scores)
            {
                item.RepaSelfCreatatedDate = DateTime.Now;
            }
            string data = JsonConvert.SerializeObject(scores);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //https://localhost:5000/api/v1/AppraisalHome/UpdateAppraisalResults?statusId=1
            //https://localhost:5000/api/v1/AppraisalHome/AddAppraisal
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/AppraisalHome/UpdateAppraisalResults?statusId=3", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                Console.WriteLine(res);
                TempData["RepaSUCCESS"] = "Successfully Submited";
                return RedirectToRoute(new { controller = "ReporteeAppraisalDashboard", action = "ReporteeAppraisalDashboard" });
                //return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
            }


            TempData["RepaError"] = "Error Occured";


            return RedirectToRoute(new { controller = "ReporteeAppraisalDashboard", action = "ReporteeAppraisalDashboard" });
        }


        //@Author : Ilyas Dabholkar
        [HttpGet]
        public IActionResult AddSelfAppraisal(int? fid)
        {
            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if(fid == null)
            {
                return RedirectToAction("HomePageAppraisal", "AppraisalHomePage");
            }

            //https://localhost:5000/api/v1/Metric/GetAllListOfMetric
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            var sessionUser = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user"); ;
            HttpResponseMessage appraisalResultResponse = client.GetAsync(client.BaseAddress + $"/AppraisalHome/GetAppraisalResultsByFidAndUserId?financialYearId={fid}&userId={sessionUser.UserId}").Result;
            var apiResponseData = appraisalResultResponse.Content.ReadAsStringAsync().Result;
            var apiResponse = JsonConvert.DeserializeObject<Response>(apiResponseData);

            List<MetricsDto> IMetric = new List<MetricsDto>();
            List<MetricsDto> BevMetric = new List<MetricsDto>();
            List<MetricsDto> JobMetric = new List<MetricsDto>();

            if (apiResponse.Data == null)
            {
                HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"/Metric/GetAllListOfMetric").Result;
                if (cardResponse.IsSuccessStatusCode)
                {
                    ViewBag.Fid = fid;
                    var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<Response>(responseData);

                    List<MetricsDto> mylist = JsonConvert.DeserializeObject<List<MetricsDto>>(JsonConvert.SerializeObject(res.Data));

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
                    ViewBag.ReadOnlyForm = false;
                    //[] bindingModel = new MetricsDto[mylist.Count()];
                    return View(mylist);
                }

            }
            else
            {
                List<AppraisalResultVM> resultData = JsonConvert.DeserializeObject<List<AppraisalResultVM>>(JsonConvert.SerializeObject(apiResponse.Data));
                List<MetricsDto> metricListData = new List<MetricsDto>();
                resultData.ForEach(item =>
                {
                    MetricsDto tempObject = new MetricsDto()
                    {
                        Metric_ID = item.MetricId,
                        List_Id = item.KraListId,
                        Metric_Description = item.MetricDescription,
                        metric_Weightage = (double)item.MetricWeightage,
                        Score = (int?)item.SelfScore,
                        Comment = item.SelfComment,
                    };

                    metricListData.Add(tempObject);

                    if (item.KraListId.Equals(1))
                    {
                        IMetric.Add(tempObject);
                    }
                    else if (item.KraListId.Equals(3))
                    {
                        BevMetric.Add(tempObject);
                    }
                    else if (item.KraListId.Equals(4))
                    {
                        JobMetric.Add(tempObject);
                    }
                });
                SelfAppraisalMetricsModel model = new SelfAppraisalMetricsModel() { IMetric = IMetric, BevMetric = BevMetric, JobMetric = JobMetric };
                Console.Write(model);
                ViewBag.AppraisalFormModel = model;
                ViewBag.ReadOnlyForm = true;
                //[] bindingModel = new MetricsDto[mylist.Count()];
                return View(metricListData);
            }
            return View();
        }

        //@Author : Ilyas Dabholkar
        [HttpPost]
        public IActionResult AddSelfAppraisal(List<MetricsDto> scores, int Fid)
        {
            Console.WriteLine(Fid);
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            AddAppraisalViewModel appraisalViewModel = new AddAppraisalViewModel();
            appraisalViewModel.UserId = (int)user.UserId;
            appraisalViewModel.FinancialYearId = Fid;
            appraisalViewModel.StartDate = DateTime.Now;
            appraisalViewModel.EndDate = DateTime.Now.AddYears(1);
            appraisalViewModel.StatusId = 1;
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;


            string Appraisaldata = JsonConvert.SerializeObject(appraisalViewModel);
            StringContent Appraisalcontent = new StringContent(Appraisaldata, Encoding.UTF8, "application/json");
            int Appraisalid = 0;
            HttpResponseMessage responseAppraisal = client.PostAsync(client.BaseAddress + "/AppraisalHome/AddAppraisal", Appraisalcontent).Result;
            if (responseAppraisal.IsSuccessStatusCode)
            {
                string AppraisalresponseData = responseAppraisal.Content.ReadAsStringAsync().Result;
                var Appraisalres = JsonConvert.DeserializeObject<ForgetPasswordResponse>(AppraisalresponseData);
                string RESAppraisaldata = JsonConvert.SerializeObject(Appraisalres.Data);
                var AppraisalresdATA = JsonConvert.DeserializeObject<AddAppraisalViewModel>(RESAppraisaldata);
                Console.WriteLine(AppraisalresdATA.Id);

                Appraisalid = (int)AppraisalresdATA.Id;



                List<AppraisalResultVM> appraisalResultsVm = new List<AppraisalResultVM>();

                foreach (var metrics in scores)
                {
                    appraisalResultsVm.Add(new AppraisalResultVM
                    {
                        KraListId = metrics.List_Id,
                        MetricId = metrics.Metric_ID,
                        UserId = (int)user.UserId,
                        MetricDescription = metrics.Metric_Description,
                        MetricWeightage = metrics.metric_Weightage,
                        SelfScore = metrics.Score,
                        SelfComment = metrics.Comment,
                        SelfCreatatedDate = DateTime.Now,
                        AppraisalId = Appraisalid




                    }); ;
                }



                Console.WriteLine(appraisalResultsVm);
                string data = JsonConvert.SerializeObject(appraisalResultsVm);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                //https://localhost:5000/api/v1/AppraisalHome/AddAppraisal
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/AppraisalHome/AddAppraisalResults", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseData);
                    var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                    Console.WriteLine(res);
                    TempData["SUCCESS"] = "Successfully Submited";
                    return RedirectToAction("HomePageAppraisal");
                    //return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
                }
            }

            TempData["Error"] = "Error Occured";


            return RedirectToAction("HomePageAppraisal");


        }

        [HttpGet]
        public IActionResult GradeReport(int? Fid, string? Fyear)
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/byYear?userId={user.UserId}").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                try
                {
                    var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Response>(responseData);
                    Console.WriteLine(data.Data);
                    ViewBag.fyear = Fyear;
                    ViewBag.Fid = Fid;
                    ViewBag.ReportingAuthorityFirstName = data.Data[0].reportingAuthorityFirstName;
                    Console.WriteLine(ViewBag.ReportingAuthorityFirstName);
                    ViewBag.ReviewingAuthorityFirstName = data.Data[0].reviewingAuthorityFirstName;
                    Console.WriteLine(ViewBag.ReviewingAuthorityFirstName);
                    ViewBag.Role = data.Data[0].role;
                    ViewBag.AppraisalStatus = data.Data[0].appraisalStatus;
                    ViewBag.Date = data.Data[0].date;
                    ViewBag.ReviewingAuthorityLastName = data.Data[0].reviewingAuthorityLastName;
                    ViewBag.ReportingAuthorityLastName = data.Data[0].reportingAuthorityLastName;
                }
                catch (Exception e)
                {
                    ViewBag.ReportingAuthorityFirstName = "Not Assigned";
                    ViewBag.ReviewingAuthorityFirstName = "Not Assigned";
                    ViewBag.Date = "1-April-2022 to 31-March-2023 ";


                }
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);

                return View();
            }
            return View();

        }


        [HttpGet]
        public IActionResult AddReviewingAuthorityAppraisal(int? Appraisald)
        {

            string x = HttpContext.Session.GetString("user");
            if (x == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Appraisald == null)
            {
                return RedirectToAction("ReviewAppraisalDashboard","ReviewAppraisal");
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"/AppraisalHome/GetAppraisalResultsByAppraisalId?id={Appraisald}").Result;
            if (cardResponse.IsSuccessStatusCode)
            {

                var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                List<ReviewingMetricDto> mylist = JsonConvert.DeserializeObject<List<ReviewingMetricDto>>(JsonConvert.SerializeObject(res.Data));

                //List<MetricsDto> IMetric = new List<MetricsDto>();
                //List<MetricsDto> BevMetric = new List<MetricsDto>();
                //List<MetricsDto> JobMetric = new List<MetricsDto>();

                //mylist.ForEach(item =>
                //{
                //    if (item.List_Id.Equals(1))
                //    {
                //        IMetric.Add(item);
                //    }
                //    else if (item.List_Id.Equals(3))
                //    {
                //        BevMetric.Add(item);
                //    }
                //    else if (item.List_Id.Equals(4))
                //    {
                //        JobMetric.Add(item);
                //    }
                //});


                //SelfAppraisalMetricsModel model = new SelfAppraisalMetricsModel() { IMetric = IMetric, BevMetric = BevMetric, JobMetric = JobMetric };
                //Console.Write(model);
                //ViewBag.AppraisalFormModel = model;
                //[] bindingModel = new MetricsDto[mylist.Count()];
                return View(mylist);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddReviewingAuthorityAppraisal(List<ReviewingMetricDto> scores)
        {
            foreach (var item in scores)
            {
                item.RevaSelfCreatatedDate = DateTime.Now;
            }
            string data = JsonConvert.SerializeObject(scores);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //https://localhost:5000/api/v1/AppraisalHome/UpdateAppraisalResults?statusId=1
            //https://localhost:5000/api/v1/AppraisalHome/AddAppraisal
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/AppraisalHome/UpdateAppraisalResults?statusId=4", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                Console.WriteLine(res);
                TempData["RepaSUCCESS"] = "Successfully Submited";
                return RedirectToRoute(new { controller = "ReviewAppraisal", action = "ReviewAppraisalDashboard" });
                //return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
            }
            TempData["RepaError"] = "Error Occured";
            return RedirectToRoute(new { controller = "ReviewAppraisal", action = "ReviewAppraisalDashboard" });
        }


    }
}
