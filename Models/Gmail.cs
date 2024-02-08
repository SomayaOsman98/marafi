using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace marafi1.Models
{
    public class Gmail
    {
        [Required(ErrorMessage = "To is required.")]
        public string To { get; set; }
        [Required(ErrorMessage = "From is required.")]
        public string From { get; set; }
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; }
    }
}