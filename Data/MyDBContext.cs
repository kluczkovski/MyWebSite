using System;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Models;

namespace MyWebSite.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; } 
    }
}
