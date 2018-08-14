using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace test5.Models
{
    public class EmployeeModel
    {


        [DataType(DataType.EmailAddress), Display(Name = "To")]
        [Required]
        public string ToEmail { get; set; }
        
        [Display(Name = "גוף ההודעה")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }
        [Display(Name = "נושא ההודעה")]
        public string EmailSubject { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "CC")]
        public string EmailCC { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "BCC")]
        public string EmailBCC { get; set; }

        public string EmailToReturn { get; set; }
    }
}