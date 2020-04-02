using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wuzzufny.Models
{
    public class Employee
    {
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        public DateTime birthDate { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        [StringLength(120)]
        public string MilitaryStatus { get; set; }

        public string MaritalStatus { get; set; }

        public string  ProfileImage{ get; set; }

    }
}