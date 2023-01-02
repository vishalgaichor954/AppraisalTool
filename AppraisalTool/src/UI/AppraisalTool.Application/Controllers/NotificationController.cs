using AppraisalTool.App.Models;
using AppraisalTool.App.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppraisalTool.App.Controllers
{
    public class NotificationController : Controller
    {
      

        private readonly ILogger<NotificationController> _logger;
        Uri baseAddress;
        HttpClient client;
        public NotificationController(ILogger<NotificationController> logger, IConfiguration configuration)
        {
            client = new HttpClient();
            baseAddress = new Uri(configuration.GetValue<string>("BaseUrl"));
            client.BaseAddress = baseAddress;
            _logger = logger;
        }
        [HttpPost]
        public JsonResult ClearNotifications(listOfNotificationId bulkDeleteVM)
        {
            string data = JsonConvert.SerializeObject(bulkDeleteVM.idList);
        //https://localhost:5000/api/Notification/ClearNotification?api-version=1
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + $"Notification/ClearNotification?api-version=1", content).Result;
            return Json(true);
        }

        [HttpGet]
        public JsonResult GetAllNotifications(int userId)
        {

            HttpResponseMessage requestresponse = client.GetAsync(client.BaseAddress + $"Notification/GetAllNotificationByUserId?id={userId}&api-version=1").Result;
            if (requestresponse.IsSuccessStatusCode)
            {


                string responseData = requestresponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseData);
                var res = JsonConvert.DeserializeObject<Response>(responseData);
                //dynamic json = JsonConvert.DeserializeObject(responseData);
                //List< NotificationVm> NotificationList = JsonConvert.DeserializeObject<List<NotificationVm>>(res.Data);

                List<NotificationVm> NotificationList = JsonConvert.DeserializeObject<List<NotificationVm>>(JsonConvert.SerializeObject(res.Data));

                return Json(NotificationList);
            }
            else
            {
                return (null);
            }


        }
    }
}
