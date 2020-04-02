using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wuzzufny.ViewModels
{
    public class CompanyProfileViewModel
    {
        public string Id { get; set; }

        //Contact information
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string JobRule { get; set; }

        public string MobileNo { get; set; }

       
        //Company basic info
        public string PhoneNo { get; set; }


        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(400)]
        public string CompanyURL { get; set; }

        public string CompanyLogo { get; set; }

        public string Companybanner { get; set; }

        [Required]
        public string Country { get; set; }

        public string CompanySize { get; set; }
        public IEnumerable<SelectListItem> CompanySizes { get; set; }

        public string Title { get; set; }

        public string CompanyIndustry { get; set; }
        public IEnumerable<SelectListItem> CompanyIndustries { get; set; }

        public string HearAboutUs { get; set; }
        public IEnumerable<SelectListItem> AboutUsHearing { get; set; }

    }
}