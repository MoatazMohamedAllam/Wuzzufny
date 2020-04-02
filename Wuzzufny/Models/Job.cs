using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wuzzufny.Models
{
    public class Job
    {
        public int Id { get; set; }

        [ForeignKey("Company")]
        public string PublisherID { get; set; }

        public Company Company { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public string ExperinceNeeded { get; set; }

        public string CareerLevel { get; set; }

        public string JobType { get; set; }

        public int Salary { get; set; }

        public string Language { get; set; }

        public string Vacancies { get; set; }

        public string Location { get; set; }


    }
}