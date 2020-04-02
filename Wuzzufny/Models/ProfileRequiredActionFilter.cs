using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace Wuzzufny.Models
{
    
    public class ProfileRequiredActionFilter : IActionFilter
    {
        private ApplicationDbContext _context;
        public ProfileRequiredActionFilter()
        {
            _context = new ApplicationDbContext();
        }
        

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var userId = _context.Users
            //                     .Where(u => u.Email == HttpContext.Current.User.Identity.Name)
            //                     .FirstOrDefault().Id;

            var urlHelper = new System.Web.Mvc.UrlHelper(filterContext.RequestContext);

            var currentUser = _context.Users.Where(u => u.Email == HttpContext.Current.User.Identity.Name).FirstOrDefault();
            if (currentUser.RoleId == 1)
            {
                var IfEmployeeHasProfile = _context.Employees.Where(e => e.Id == currentUser.Id).FirstOrDefault();
                if (IfEmployeeHasProfile == null)
                {
                    filterContext.Result = new RedirectResult(urlHelper.Action("Create","Employees"));
                }
            }

            if (currentUser.RoleId == 2)
            {
                var IfCompanyHasProfile = _context.Companies.Where(e => e.Id == currentUser.Id).FirstOrDefault();

                if (IfCompanyHasProfile == null)
                {
                    //filterContext.Result = new RedirectResult(urlHelper.Action("Create", "Companies"));
                    filterContext.Result = new RedirectResult("/Companies/Create");
                }

            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}