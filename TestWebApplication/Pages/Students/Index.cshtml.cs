using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanCode.BCEL.DataAndEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Data;
using TestWebApplication.Models;

namespace TestWebApplication
{
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<Student> _context;

        public IndexModel(IGenericRepository<Student> context)
        {
            _context = context;
        }

        public IPagedList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Where(false).ToPagedListAsync(1, 3);
        }
    }
}
