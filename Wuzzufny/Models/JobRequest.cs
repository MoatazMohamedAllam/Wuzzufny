using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wuzzufny.Models
{
    public class JobRequest
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }

        public Job Job { get; set; }

        public DateTime? RequestDate { get; set; }

        public string RequestStatus { get; set; }

    }
}