using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wuzzufny.ViewModels
{
    public class JobViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string Requirements { get; set; }

        [Required]
        public string ExperinceNeeded { get; set; }

        [Required]
        public string CareerLevel { get; set; }

        [Required]
        public string JobType { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Vacancies { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Title { get; set; }
    }
}