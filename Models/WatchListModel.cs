using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieBlend.Models
{
    public class WatchListModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string movieId { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public bool isMovie { get; set; }
    }
}
