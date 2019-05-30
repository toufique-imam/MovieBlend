using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieBlend.Models
{
    public class Comment
    {
        [Required]
        public  Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTimeOffset posteddate{get;set;}
        [Required]
        public Guid BlogPostID { get; set; }
    }
}