using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wuzzufny.ViewModels
{
    public class EmployeeProfileViewModel
    {
        public string  Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        public string User_ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required]
        [Display(Name ="Date Of Birth")]
        public DateTime birthDate { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        [Display(Name = "Military Status")]
        public string MilitaryStatus { get; set; }

        public IEnumerable<SelectListItem> Militaries { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Display(Name ="Profile Image")]
        public string ProfileImage { get; set; }


    }
}