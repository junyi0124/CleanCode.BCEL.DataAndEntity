using ContosoUniversityMvc.Models;
using CleanCode.BCEL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityMvc.Data
{
    public class StudentRepository : GenericRepository<Student, int>
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
