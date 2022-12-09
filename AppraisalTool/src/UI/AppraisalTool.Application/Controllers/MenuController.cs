using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppraisalTool.App.Controllers
{
    public class MenuController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/");
        HttpClient client = new HttpClient();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult CreateMenu()
        {
            Dictionary<string, int> roleDict = new Dictionary<string, int>();
            roleDict.Add("Admin", 1);
            roleDict.Add("Reporting Authority", 2);
            roleDict.Add("Reviewing Authority", 3);
            roleDict.Add("Employee", 4);
            ViewBag.RoleList = roleDict;
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(List<int> selectedRoles, MenuModel model)
        {
            //Menu / AddMenu ? api - version = 1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            ModelState.Remove("RoleList");
            if (ModelState.IsValid)
            {
                model.AddedBy = userSession.UserId;
                model.RoleList = selectedRoles;
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Menu/AddMenu?api-version=1", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AddMenuSuccess"] = "Menu Added Successfully";
                    return RedirectToAction("ListMenu");
                }
            }
            TempData["AddMenuFaild"] = "Failed to Add Menu";
            return RedirectToAction("ListMenu");
            
        }

        [HttpGet]
        public IActionResult UpdateMenu(int id)
        {

            Dictionary<string, int> roleDict2 = new Dictionary<string, int>();
            roleDict2.Add("ADMINISTRATOR", 1);
            roleDict2.Add("REPORTINGAUTHORITY", 2);
            roleDict2.Add("REVIEWINGAUTHORITY", 3);
            roleDict2.Add("EMPLOYEE", 4);
            ViewBag.RoleList = roleDict2;
            MenuModel menu = new MenuModel();
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            
            //getmenubyid api
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Menu/GetMenuById?id={id}&api-version=1").Result;

       
            //getallmenus api
            HttpResponseMessage response1 = client.GetAsync(client.BaseAddress + "Menu/ListAllMenu?api-version=1").Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<Response>(data);
                var serres = JsonConvert.SerializeObject(res.Data);
                menu = JsonConvert.DeserializeObject<MenuModel>(serres);
                List<int> rolelist = new List<int>();
                //foreach (var item in res.Data)
                //{
                    
                //    rolelist.Add(item.roleList);
                //    Console.WriteLine(item.roleList);
                    
                //}
                
                rolelist.AddRange(menu.RoleList);
                
                var data1 = response1.Content.ReadAsStringAsync().Result;
                var getallmenu = JsonConvert.DeserializeObject<Response>(data1);
                Dictionary<string, int> roledict = new Dictionary<string, int>();
                foreach (var item in getallmenu.Data)
                {
                    foreach (var i in rolelist)
                    {
                        if (i == (int)item.roleId && item.menu_Id ==id)
                        {

                            roledict.Add((string)item.roleName, (int)item.roleId);
                        }
                    }

                }
                ViewBag.roldict=roledict;
  
                var roledict3 = roledict.Except(roleDict2).Concat(roleDict2.Except(roledict));
                ViewBag.roledict3 = roledict3;
              
            }
            return View(menu);
        }

       
        [HttpPost]
        public IActionResult UpdateMenu(MenuModel model, List<int> selectedRoles)
        {
          var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
            EditMenuModel editmodel = new EditMenuModel()
            {
                Menu_Id = model.menu_Id,
                MenuText=model.MenuText,
                MenuClass=model.MenuClass,
                MenuIcon=model.MenuIcon,
                MenuFlag=model.MenuFlag,
                MenuController=model.MenuController,
                MenuAction=model.MenuAction,
                MenuLink=model.MenuLink,
                UpdatedBy=userSession.UserId,
                RoleList= selectedRoles
                
            };

            string data = JsonConvert.SerializeObject(editmodel);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("https://localhost:5000/api/Menu/UpdateMenu?api-version=1", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Menu Update Successfully";
                return RedirectToAction("ListMenu");
            }
            TempData["editError"] = "Faild to Update Menu";
            return RedirectToAction("ListMenu");



        }

        [HttpGet]
        public IActionResult ListMenu()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Menu?api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {

                string responseData = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(responseData);
               
                ViewBag.MenuList = json.data;
                return View();
                //[...new Set(varjson.DATA.map(({ name })=>name))]

            }
            return View();
        }
        public IActionResult DeleteMenu(int id)
        {
            //User/removeUser?id=9&api-version=1
            Console.WriteLine("PostMethod hit");
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            //var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            //model.upda = userSession.UserId;
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Menu/removeMenu?id={id}&api-version=1").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(data);

                TempData["DeleteMenuSuccess"] = "Menu Delete Successfully";
                return RedirectToAction("ListMenu");
            }
            TempData["DeleteMenuFaild"] = "Menu to Delete User";
            return RedirectToAction("ListMenu");
        }

        
       


    }
}
