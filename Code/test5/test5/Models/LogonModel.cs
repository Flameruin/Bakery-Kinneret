using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace test5.Models
{
    public class LogonModel
    {
        /// Gets or sets the name of the user.
        [Required]
        public string UserName { get; set; }

        /// Gets or sets the password.
        [Required]
        public string Password { get; set; }
    }
}