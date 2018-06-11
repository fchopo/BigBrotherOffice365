using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigBrotherO365.Data
{
    public class O365Subscription
    {
        [Display(Name = "Content Type")]
        public string contentType { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
    }
}
