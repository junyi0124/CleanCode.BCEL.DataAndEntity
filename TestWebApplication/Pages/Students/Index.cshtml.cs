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
        private readonly IGenericRepository<Student, int> _repo;

        public IndexModel(IGenericRepository<Student, int> context)
        {
            _repo = context;
        }

        public Paged<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _repo
                //.ToPagedListAsync(1, 3);
                //.ToPagedDataAsync(1, 3);
                //.ToPagedDataAsync(1, 2)
                .GetPaged(null, 1, 2);
        }
    }
}
