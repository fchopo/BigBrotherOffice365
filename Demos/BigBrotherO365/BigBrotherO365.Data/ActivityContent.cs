using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BigBrotherO365.Data
{
    public class ActivityContent
    {
        [Display(Name ="Content URI")]
        public string contentUri { get; set; }
        [Display(Name = "Content ID")]
        public string contentId { get; set; }
        [Display(Name = "Content Type")]
        public string contentType { get; set; }
        [Display(Name = "Content Created")]
        public DateTime contentCreated { get; set; }
        [Display(Name = "Content Expiration")]
        public DateTime contentExpiration { get; set; }
    }
}
