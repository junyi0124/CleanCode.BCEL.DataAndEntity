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
    }
}
