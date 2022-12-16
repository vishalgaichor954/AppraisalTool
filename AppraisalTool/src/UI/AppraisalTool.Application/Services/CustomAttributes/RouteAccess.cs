using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models.AppraisalToolAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Syncfusion.EJ2.Linq;

namespace AppraisalTool.App.Services.CustomAttributes
{
    public class RouteAccess : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(filterContext.HttpContext.Session, "user");
            if(userSession != null)
            {
                string[] words = Roles.Split(',');
                if (!words.Contains(userSession.Role))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"Controller", "Dashboard" },
                        { "Action", "Dashboard" }
                    });
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"Controller", "Login" },
                        { "Action", "Login" }
                    });
            }

            //string userId = session.GetString("UserId");
            //string role = session.GetString("Role");
            //if (userId == null || role != "Admin")
            //{
            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
            //        {
            //            {"Controller", "Login" },
            //            { "Action", "Login" }
            //        });
            //}
        }
    }
}
