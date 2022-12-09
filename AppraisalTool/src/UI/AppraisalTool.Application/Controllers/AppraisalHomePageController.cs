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
//using AppraisalTool.Domain.Entities;
using System.Security.Cryptography;
using AppraisalTool.App.Models.FinancialYear;
using AppraisalTool.Domain.Common;

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
            ViewBag.UserId = user.UserId;
            SelfAppraisalHome model = new SelfAppraisalHome();
            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome?userId={user.UserId}").Result;
            HttpResponseMessage cardResponse = client.GetAsync($"https://localhost:5000/api/User/GetAllCard?id={user.RoleId}&api-version=1").Result;
            HttpResponseMessage reportResponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetReporteeAppraisalByRepAuthority?id={user.UserId}").Result;
            HttpResponseMessage reviewResponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetReviewAppraisalByRevAuthority?id={user.UserId}").Result;
            HttpResponseMessage yearResponse = client.GetAsync($"https://localhost:5000/api/v1/FinancialYear/GetFinancialYearsByUserJoining?userId={user.UserId}").Result;


            if (httpResponseMessage.IsSuccessStatusCode && cardResponse.IsSuccessStatusCode && reportResponse.IsSuccessStatusCode && reviewResponse.IsSuccessStatusCode && yearResponse.IsSuccessStatusCode)
            {
                int totalReportee = 0;
                int totalReview = 0;
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
                    if(item.status != 1)
                    {
                        totalReportee = totalReportee + 1;
                    }


                }
                ViewBag.PendingAtReportee = reporteeCount;
                //ViewBag.ReporteeCompleted = reporteeCompleted;
               
                ViewBag.ReporteeCompleted = totalReportee;


                var reviewData = reviewResponse.Content.ReadAsStringAsync().Result;
                var employees = JsonConvert.DeserializeObject<Response>(reviewData);
                Console.WriteLine(employees.Data);
                

                foreach(var item in employees.Data)
                    {
                    if (item.status == 3)
                    {
                        reviewCount = reviewCount + 1;
                    }
                    if(item.status!=1 && item.status!=2)
                    {
                        totalReview = totalReview + 1;
                    }


                }
                
                ViewBag.PendingAtReview = reviewCount;
                ViewBag.ReviewCompleted = totalReview;


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

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/byYear?userId={user.UserId}&FyId={Fid}").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data.Data);
                if(data.Data.Count!=0 )
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
                            ViewBag.Date = item.startDate + " " + " " + "to" + " " +item.endDate;
                            ViewBag.ReviewingAuthorityLastName = item.reviewingAuthorityLastName;
                            ViewBag.ReportingAuthorityLastName = item.reportingAuthorityLastName;
                        }
                        else
                        {
                            ViewBag.ReportingAuthorityFirstName = item.reportingAuthorityFirstName;
                            Console.WriteLine(ViewBag.ReportingAuthorityFirstName);
                            ViewBag.Fid = Fid;
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
                    ViewBag.Fid = Fid;
                    ViewBag.ReportingAuthorityFirstName = "Not Assigned";
                    ViewBag.ReviewingAuthorityFirstName = "Not Assigned";
                    ViewBag.Date = "Not Applicable";



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
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            ViewBag.fid = fid;
            ViewBag.uid = user.UserId;
            AppraisalResponseVm appraisalResult = new AppraisalResponseVm();
            //https://localhost:5000/api/v1/Metric/GetAllListOfMetric
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            var sessionUser = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user"); ;
            HttpResponseMessage appraisalResultResponse = client.GetAsync(client.BaseAddress + $"/AppraisalHome/GetAppraisalResultsByFidAndUserId?financialYearId={fid}&userId={sessionUser.UserId}").Result;
            var apiResponseData = appraisalResultResponse.Content.ReadAsStringAsync().Result;
            var apiResponse = JsonConvert.DeserializeObject<Response>(apiResponseData);

            List<updateSelfAppraisalVM> IMetric = new List<updateSelfAppraisalVM>();
            List<updateSelfAppraisalVM> BevMetric = new List<updateSelfAppraisalVM>();
            List<updateSelfAppraisalVM> JobMetric = new List<updateSelfAppraisalVM>();

            HttpResponseMessage appraisalResponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetAppraisalByFidandUserId?fId={fid}&userId={sessionUser.UserId}").Result;
            if(appraisalResponse.IsSuccessStatusCode)
            {
                var appraisal  = appraisalResponse.Content.ReadAsStringAsync().Result;

                appraisalResult = JsonConvert.DeserializeObject<AppraisalResponseVm>(appraisal);
                ViewBag.appraisalData = appraisalResult;
               

            }

            if (apiResponse.Data == null)
            {
                HttpResponseMessage cardResponse = client.GetAsync(client.BaseAddress + $"/Metric/GetAllListOfMetric").Result;

                if (cardResponse.IsSuccessStatusCode )
                {
                    ViewBag.Fid = fid;
                    var responseData = cardResponse.Content.ReadAsStringAsync().Result;
                    var res = JsonConvert.DeserializeObject<Response>(responseData);

                    List<updateSelfAppraisalVM> mylist = JsonConvert.DeserializeObject<List<updateSelfAppraisalVM>>(JsonConvert.SerializeObject(res.Data));

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
                    ViewBag.IsEditable = 0;
                    return View(mylist);
                }

            }
            else
            {
                List<AppraisalResultVM> resultData = JsonConvert.DeserializeObject<List<AppraisalResultVM>>(JsonConvert.SerializeObject(apiResponse.Data));
                List<updateSelfAppraisalVM> metricListData = new List<updateSelfAppraisalVM>();
                resultData.ForEach(item =>
                {
                    updateSelfAppraisalVM tempObject = new updateSelfAppraisalVM()
                    {
                        Id=(int)item.ID,
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
                ViewBag.appraisalStatus = appraisalResult.StatusId;
                if (appraisalResult.Editable == true)
                {
                    ViewBag.IsEditable = 1;
                }
                else
                {
                    ViewBag.IsEditable = 0;
                }





                //[] bindingModel = new MetricsDto[mylist.Count()];
                return View(metricListData);
            }
            return View();
        }

        //@Author : Ilyas Dabholkar
        [HttpPost]
        public IActionResult AddSelfAppraisal(List<updateSelfAppraisalVM> scores, int Fid,int IsEditable,int AppraisalID)
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            Console.WriteLine(IsEditable);
            if (IsEditable == 1)
            {

                List<AppraisalResultVM> appraisal = new List<AppraisalResultVM>();

                foreach (var item in scores)
                {
                    AppraisalResultVM appraisalResultVM = new AppraisalResultVM();
                    appraisalResultVM.AppraisalId = AppraisalID;
                    appraisalResultVM.MetricId = item.Metric_ID;
                    appraisalResultVM.KraListId = item.List_Id;
                    appraisalResultVM.MetricDescription = item.Metric_Description;
                    appraisalResultVM.MetricWeightage = item.metric_Weightage;
                    appraisalResultVM.SelfScore = item.Score;
                    appraisalResultVM.SelfComment = item.Comment;
                    appraisalResultVM.UserId =(int) user.UserId;
                    appraisalResultVM.ID = item.Id;
                    appraisal.Add(appraisalResultVM);


                }

                Console.WriteLine(appraisal);
                string data = JsonConvert.SerializeObject(appraisal);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                //https://localhost:5000/api/v1/AppraisalHome/UpdateAppraisalResults?statusId=1
                //https://localhost:5000/api/v1/AppraisalHome/AddAppraisal
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/AppraisalHome/UpdateAppraisalResults?statusId=2", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseData);
                    var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                    Console.WriteLine(res);
                    TempData["UpdateSUCCESS"] = " Updated Successfully";
                    

                    //return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
                    AllowAppraisalEditVm allowAppraisalEditVm = new AllowAppraisalEditVm();
                    allowAppraisalEditVm.AppraisalId = AppraisalID;
                    allowAppraisalEditVm.IsAllowed = false;
                    string Editdata = JsonConvert.SerializeObject(allowAppraisalEditVm);

                    StringContent Editcontent = new StringContent(Editdata, Encoding.UTF8, "application/json");
                    HttpResponseMessage Editresponse = client.PutAsync("https://localhost:5000/api/v1/AppraisalHome/AllowEdit", Editcontent).Result;

                   
                        return RedirectToAction("HomePageAppraisal");
                    
                   
                }
                TempData["UpdateError"] = " Oops!! something went wrong";
                return RedirectToAction("HomePageAppraisal");
            }
            else
            {

            
            Console.WriteLine(Fid);
       
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
            //HttpResponseMessage requestEdit = client.PostAsync("://localhost:5000/api/v1/AppraisalHome/RequestEdit", Appraisalcontent).Result;

            if (responseAppraisal.IsSuccessStatusCode /*&& requestEdit.IsSuccessStatusCode*/)
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
        }

        [HttpGet]
        public IActionResult GradeReport(int? Fid, string? Fyear)
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/byYear?userId={user.UserId}&FyId={Fid}").Result;

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
                    ViewBag.Date = data.Data[0].startDate + " " + " " + "to" + " " + data.Data[0].endDate;
                    ViewBag.ReviewingAuthorityLastName = data.Data[0].reviewingAuthorityLastName;
                    ViewBag.ReportingAuthorityLastName = data.Data[0].reportingAuthorityLastName;
                }
                catch (Exception e)
                {
                    ViewBag.ReportingAuthorityFirstName = "Not Assigned";
                    ViewBag.ReviewingAuthorityFirstName = "Not Assigned";
                    //ViewBag.Date = "1-April-2022 to 31-March-2023 ";


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

        [HttpGet]
        public IActionResult  RequestForEdit(int? fId, int? userId)
        {
                        HttpResponseMessage requestresponse = client.GetAsync( $" https://localhost:5000/api/v1/AppraisalHome/RequestToEdit?fId={fId}&userId={userId}").Result;

        //https://localhost:5000/api/v1/AppraisalHome/RequestToEdit?fId=4&userId=5
        if(requestresponse.IsSuccessStatusCode)
            {
                TempData["RequestSuccess"] = "Your Request for updation was raised successfully";
                return RedirectToAction("HomePageAppraisal");
            }
            TempData["RequestError"] = "Oops!! Something Went Wrong";
            return RedirectToAction("HomePageAppraisal");


        }
        [HttpGet]
        public JsonResult startDateEndDate(int id)
        {
            
            HttpResponseMessage requestresponse = client.GetAsync($"https://localhost:5000/api/FinancialYear/GetFinancialYearById?id={id}&api-version=1").Result;
            
            //https://localhost:5000/api/v1/AppraisalHome/RequestToEdit?fId=4&userId=5
            if (requestresponse.IsSuccessStatusCode)
            {
                string responseData = requestresponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<financialResponse>(responseData);
                return Json(res.Data);
            }
            else
            {
                return (null);
            }
            
            
        }


        [HttpGet]
        public JsonResult PendingAppriasalCount(int id,int userId)
        {

            HttpResponseMessage requestresponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetAppraisalByFidandUserId?fId={id}&userId={userId}").Result;

        https://localhost:5000/api/v1/AppraisalHome/GetAppraisalByFidandUserId?fId=4&userId=47
            if (requestresponse.IsSuccessStatusCode)
            {

                
                string responseData = requestresponse.Content.ReadAsStringAsync().Result;
                if (responseData == string.Empty)
                {
                    return Json(1);
                }
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<pendingAppraisalVm>(responseData);
                Console.WriteLine(res.statusId);
                return Json(res.statusId);
            }
            else
            {
                return (null);
            }


        }

        [HttpGet]
        public JsonResult GetPendingAppraisalCount( int userId)
        {

            HttpResponseMessage requestresponse = client.GetAsync($"https://localhost:5000/api/v1/AppraisalHome/GetReporteeAppraisalByRepAuthority?id={userId}").Result;

       
            if (requestresponse.IsSuccessStatusCode)
            {


                string responseData = requestresponse.Content.ReadAsStringAsync().Result;
                if (responseData == string.Empty)
                {
                    return Json(1);
                }
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                List<ReporteeAppraisalListVm> resdata= JsonConvert.DeserializeObject<List<ReporteeAppraisalListVm>>(JsonConvert.SerializeObject(res.Data));
                Console.WriteLine(resdata.Count);
                int countOfpendingReport = 0;
                foreach (var item in resdata)
                {
                    
                    if (item.Status == 2)
                    {
                        countOfpendingReport++; 
                    }
                    
                }
                return Json(countOfpendingReport);
            }
            else
            {
                return Json(0);
            }


        }




    }
}
