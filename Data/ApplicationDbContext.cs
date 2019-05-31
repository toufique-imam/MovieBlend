using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieBlend.Models;
namespace MovieBlend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieData> Movies{get;set;}
        public DbSet<MovieData> TV{get;set;}
        //public DbSet<Comment> Comments{get;set;}
        public virtual DbSet<Image> Images { get; set; }
    }
}
