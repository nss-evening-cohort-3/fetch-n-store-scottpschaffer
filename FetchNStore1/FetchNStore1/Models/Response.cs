using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FetchNStore1.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }

        [Required]
        public string StatusCode { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public int ResponseTime { get; set; }

        public string HTTPMethod { get; set; }

        public DateTime RequestTime { get; set; }
    }
}