using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Umpraco.Models
{
    public class ContactModel
    {
        [Required]
        [Display(Name = "Subject:")]
        public string Subject { get; set; }

        //[Required]
        //[Display(Name = "Last Name:")]
        //public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Message:")]
        public string Message { get; set; }

    }
}