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

        //@Author : Abhishek Singh
        public IActionResult Login()
        {
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if (userSession != null)
            {
                return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
            }
            return View();
        }

        //@Author : Abhishek Singh
        public IActionResult Register()
        {
            return View();
        }


        //@Author : Ilyas Dabholkar
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
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.BaseAddress = baseAddress;
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Auth/Login?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    LoginResponseDto AuthData = JsonConvert.DeserializeObject<LoginResponseDto>(responseData);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "user", AuthData);
                    TempData["Sucess"] = AuthData.Name;
                    return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
                }
                TempData["Error"] = "Failed to Login User";
                return View();
            }
            return View();
        }

        //@Author : Ilyas Dabholkar
        [HttpGet]
        public IActionResult UserLogout()
        {           
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }

        //@Author : Abhishek Singh
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if (userSession != null)
            {
                return RedirectToRoute(new { controller = "Dashboard", action = "Dashboard" });
            }
            return View();
        }

        //@Author : Abhishek Singh
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgotPasswordView)
        {
            string data = JsonConvert.SerializeObject(forgotPasswordView);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Auth/ForgotPassword?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                if (res.Succeeded)
                {
                    TempData["PassReset"] = "Check your Email for new Login Credentials";
                }

                return View();
            }

            return View();
        }

        //@Author : Abhishek Singh
        [HttpGet]
        public JsonResult UserExistsEmail(string email)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/Auth?email={email}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ForgetPasswordResponse>(responseData);
                if (res.Succeeded == true)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
    }
}

