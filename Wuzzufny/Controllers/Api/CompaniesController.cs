using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wuzzufny.Models;

namespace Wuzzufny.Controllers.Api
{
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPut]
        public IHttpActionResult RejectRequest(int requestID)
        {
            var request = _context.JobRequests.Where(r => r.Id == requestID).FirstOrDefault();

            if (request == null)
                return NotFound();

            request.RequestStatus = "rejected";
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AcceptRequest(int requestID)
        {
            var request = _context.JobRequests.Where(r => r.Id == requestID).FirstOrDefault();

            if (request == null)
                return NotFound();

            request.RequestStatus = "accepted";
            _context.SaveChanges();

            return Ok();
        }

    }
}
