using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models.AppraisalToolAuth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class LoginController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if (userSession != null)
            {
                return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                // Validate Captcha Code
                if (!Captcha.ValidateCaptchaCode(login.CaptchaCode, HttpContext))
                {
                    TempData["type"] = "danger";
                    TempData["msg"] = "Invalid Captcha";
                    return View();
                }

                string data = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
                
                HttpClient client = new HttpClient();
                client.BaseAddress = baseAddress;
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Auth/Login?api-version=1",content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseData);
                    LoginResponseDto AuthData = JsonConvert.DeserializeObject<LoginResponseDto>(responseData);

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "user",AuthData);

                    return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
                }
                TempData["Error"] = "Faild to Login User";
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserLogout()
        {
            Console.WriteLine(HttpContext.Session.GetString("user"));
            HttpContext.Session.Remove("user");
            Console.WriteLine($"NUll : {HttpContext.Session.GetString("user")}");
            return RedirectToAction("Login");
        }
    }
}
