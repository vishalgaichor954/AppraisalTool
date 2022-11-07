using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.Navbar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class AppraisalHomePageController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:5000/api");

        public IActionResult HomePageAppraisal()
        {
            var user = SessionHelper.GetObjectFromJson<SelfAppraisalHome>(HttpContext.Session, "user");
            if (user != null)
            {
                ViewBag.UserId = user.UserId;
                ViewBag.UserRole = user.Role;
                ViewBag.FinanceId = user.FinancialYearId;
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
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            List<AppraisalResultVM> appraisalResultsVm = new List<AppraisalResultVM>();

            foreach(var metrics in scores)
            {
                appraisalResultsVm.Add(new AppraisalResultVM
                {
                    KraListId = metrics.List_Id,
                    MetricId = metrics.Metric_ID,
                    UserId= (int)user.UserId,
                    MetricDescription=metrics.Metric_Description,
                    MetricWeightage=metrics.metric_Weightage,
                    SelfScore=metrics.Score,
                    SelfComment=metrics.Comment,
                    SelfCreatatedDate= DateTime.Now,




                });
            }

            Console.WriteLine(appraisalResultsVm);
           string data = JsonConvert.SerializeObject(appraisalResultsVm);
           StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/v1/AppraisalHome/AddAppraisalResults", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                Console.WriteLine(res);
                //return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
            }


            return RedirectToAction("AddSelfAppraisal");


        }
    }

}
