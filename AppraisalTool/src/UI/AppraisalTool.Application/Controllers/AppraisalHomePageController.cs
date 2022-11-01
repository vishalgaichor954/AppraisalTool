using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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

        public IActionResult HomePageAppraisal()
        {
            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/AppraisalHome/byYear?yearId=1&userId={user.UserId}").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response>(responseData);
                Console.WriteLine(data.Data);
                List<SelectListItem> financialYearList = new List<SelectListItem>();
                foreach (var item in data.Data)
                {

                    financialYearList.Add(new SelectListItem { Text = item.startYear.ToString(), Value = item.id.ToString() });

                }
                ViewBag.financialYearList = financialYearList;
                return View();


            

            }
            return View();

        }
    }
}
