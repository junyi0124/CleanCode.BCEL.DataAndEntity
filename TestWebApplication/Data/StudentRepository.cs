using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.BCEL.DataAndEntity;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Models;

namespace TestWebApplication.Data
{
    public class StudentRepository : GenericRepository<Student, int>
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }


    }
}
