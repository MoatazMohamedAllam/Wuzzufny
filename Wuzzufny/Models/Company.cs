using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wuzzufny.Models
{
    public class Company
    {
        public string Id { get; set; }

        //Contact information
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobRule { get; set; }

        public string MobileNo { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        //Company basic info
        public string PhoneNo { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(400)]
        public string CompanyURL { get; set; }

        public string CompanyLogo { get; set; }

        public string Companybanner { get; set; }

        public string CompanySize { get; set; }

        public string Title { get; set; }

        public string CompanyIndustry { get; set; }

        public string HearAboutUs { get; set; }

        public string Country { get; set; }

    }
}