using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace MovieBlend.Models
{

    public class MovieData
    {
        public Guid Id { get; set; }
        public string PosterId {get;set;}
        public DateTimeOffset? Postedate { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Release { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Language { get; set; }
        public Catagory Catagoryx { get; set; }
        public string User_name { get; set; }

        
        
    }
    public enum Catagory{
        Movie,
        Tv
    }
    public enum Lang{
        English,
        Bangla,
        France,
        German,
        India,
        Japanese,
        Chinese,
        Spanish,
        Portuguese,
        Arabic,
        Other
    }
}
