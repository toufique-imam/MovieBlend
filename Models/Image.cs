using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlend.Models
{
    public class Image
    {
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }
        [Required]
        public byte[] Data { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string ContentType { get; set; }

    }
}
