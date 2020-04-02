using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Wuzzufny.Models
{
    public class ProfileRequiredAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var urlHelper = new System.Web.Mvc.UrlHelper(filterContext.RequestContext);

            var currentUser = _context.Users.Where(u => u.Email == HttpContext.Current.User.Identity.Name).FirstOrDefault();

            if (currentUser != null)
            {
                if (currentUser.RoleId == 1)
                {
                    var IfEmployeeHasProfile = _context.Employees.Where(e => e.Id == currentUser.Id).FirstOrDefault();
                    if (IfEmployeeHasProfile == null)
                    {
                        filterContext.Result = new RedirectResult(urlHelper.Action("Create", "Employees"));
                    }
                }

                if (currentUser.RoleId == 2)
                {
                    var IfCompanyHasProfile = _context.Companies.Where(e => e.Id == currentUser.Id).FirstOrDefault();

                    if (IfCompanyHasProfile == null)
                    {
                        //filterContext.Result = new RedirectResult(urlHelper.Action("Create", "Companies"));
                        filterContext.Result = new RedirectResult(urlHelper.Action("Create", "Companies"));
                    }

                }
            }
           

            base.OnActionExecuting(filterContext);

        }


    }
}