using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models.AppraisalToolAuth;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalTool.App.Controllers
{
    public class AppraisalHomePageController : Controller
    {
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
    }
}
