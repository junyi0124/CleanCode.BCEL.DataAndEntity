using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApplication.Models;

namespace TestWebApplication.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> opt) : base(opt)
        {

        }

        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Age = 22, Bio = "", Gender = false, Name = "Alice" },
                new Student { Id = 2, Age = 22, Bio = "", Gender = true, Name = "Bob" },
                new Student { Id = 3, Age = 21, Bio = "", Gender = false, Name = "Ivy" },
                new Student { Id = 4, Age = 27, Bio = "", Gender = true, Name = "Admin" },
                new Student { Id = 5, Age = 31, Bio = "", Gender = true, Name = "Chief" }
                );
        }
    }
}
