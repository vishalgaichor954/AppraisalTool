using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
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
               

                SelfAppraisalMetricsModel model = new SelfAppraisalMetricsModel() { IMetric = IMetric,BevMetric = BevMetric,JobMetric=JobMetric};
                Console.Write(model);
                ViewBag.AppraisalFormModel = model;
                return View();
            }
            return View();

        }
    }
}
