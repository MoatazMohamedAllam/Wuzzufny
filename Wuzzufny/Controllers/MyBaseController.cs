using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wuzzufny.Models;

namespace Wuzzufny.Controllers
{
    public class MyBaseController : Controller
    {
        private ApplicationDbContext _context;


        public MyBaseController()
        {
            _context = new ApplicationDbContext();

            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var user = _context.Users.Where(u => u.Id == userId ).Single();

                var employeeProfile = _context.Employees.Include(e => e.User).Where(e => e.Id == userId).FirstOrDefault();
                var companyProfile = _context.Companies.Include(e => e.User).Where(e => e.Id == userId).FirstOrDefault();
                
                if(user.RoleId == 1 && employeeProfile != null)
                {
                    ViewBag.empProfile = employeeProfile;
                }
                else if(user.RoleId == 2 && companyProfile != null)
                {
                    ViewBag.compProfile = companyProfile;
                }
                else
                {
                    ViewBag.UserProfile = user;
                }
            }
            else
            {
                ViewBag.UserProfile = "";

            }

        }

        

        public string EmployeeRole()
        {
            return _context.UserRoles.Where(e => e.Id == 1).FirstOrDefault().RoleName;
        }

        public string CompanyRole()
        {
            return _context.UserRoles.Where(e => e.Id == 2).FirstOrDefault().RoleName;
        }

        public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectedList = new List<SelectListItem>();
            
            foreach (var element in elements)
            {
                selectedList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return selectedList;
        }

        public IEnumerable<string> GetCountries()
        {
            var countryList = new List<string>();
            var cultureInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var cultureInfo in cultureInfoList)
            {
                var regionInfo = new RegionInfo(cultureInfo.LCID);
                if (!(countryList.Contains(regionInfo.EnglishName)))
                {
                    countryList.Add(regionInfo.EnglishName);
                }

            }

            countryList.Sort();

            return countryList;
        }


    }
}