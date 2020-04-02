using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wuzzufny.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;

namespace Wuzzufny.Controllers
{
    [AuthorizeEmployee]
    public class JobsController : MyBaseController
    {
        private ApplicationDbContext _context;

        public JobsController()
        {
            _context = new ApplicationDbContext();
        }

    public ActionResult AllJobs(string searchTerm, int? page)
    {
        var userId = User.Identity.GetUserId();

        ViewBag.CurrentUser = userId;
        var jobs = _context.Jobs.Include(j => j.Company).ToList();


            var ApplyedJobsIds = _context.JobRequests.Where(e => e.EmployeeId == userId).ToList().Select(e => e.JobId);
            ViewBag.ApplyedJobs = ApplyedJobsIds;
            
      
        if (!String.IsNullOrWhiteSpace(searchTerm))
        {
            jobs = _context.Jobs
                                .Where(j => j.Title.Contains(searchTerm) || j.Location.Contains(searchTerm)
                                        || j.Company.CompanyName.Contains(searchTerm))
                                .Include(j => j.Company)
                                .ToList();

        }

        return View(jobs.ToPagedList(page ?? 1, 3));
    }
}

}