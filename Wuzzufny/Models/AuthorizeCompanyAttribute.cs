using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wuzzufny.Models
{
    public class AuthorizeCompanyAttribute : AuthorizeAttribute
    {
        private ApplicationDbContext _context;

        public AuthorizeCompanyAttribute()
        {
            _context = new ApplicationDbContext();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                                                    new RouteValueDictionary(
                                                        new { controller = "Account", action = "Login" }));
            }
            base.HandleUnauthorizedRequest(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            var currentUser = _context.Users.Where(e => e.Email == HttpContext.Current.User.Identity.Name).FirstOrDefault();
            IPrincipal user = httpContext.User;
            if (currentUser != null)
            {
                if (!user.Identity.IsAuthenticated || currentUser.RoleId != 2)
                {
                    return false;
                }
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}