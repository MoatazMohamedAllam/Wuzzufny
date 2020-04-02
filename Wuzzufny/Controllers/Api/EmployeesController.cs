using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wuzzufny.Models;

namespace Wuzzufny.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Job> AllJobs()
        {
            //var userID = User.Identity.GetUserId();
            return _context.Jobs.Include(j => j.Company).ToList();
        }

        
        [HttpPost]
        public IHttpActionResult ApplyForJob(int id)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.JobRequests.Any(e => e.EmployeeId == userId && e.JobId == id);

            if (!ModelState.IsValid || exists)
            {
                return BadRequest();
            }


            var selectedJob = _context.Jobs.Where(e => e.Id == id).FirstOrDefault();

            var request = new JobRequest();
            request.CompanyId = selectedJob.PublisherID;
            request.JobId = selectedJob.Id;
            request.EmployeeId = userId;
            request.RequestStatus = "pending";

            _context.JobRequests.Add(request);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IEnumerable<JobRequest> GetRequestsStatus()
        {
            var userId = User.Identity.GetUserId();

            var applyRequests = _context.JobRequests
                                        .Include(r => r.Job)
                                        .Include(r => r.Company)
                                        .Where(r => r.EmployeeId == userId)
                                        .ToList();

            return applyRequests;
        }




    }
}
