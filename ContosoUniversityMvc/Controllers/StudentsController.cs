using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityMvc.Data;
using ContosoUniversityMvc.Models;
using CleanCode.BCEL.DataAccess;

namespace ContosoUniversityMvc.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly SchoolContext _context;

        //public StudentsController(SchoolContext context)
        //{
        //    _context = context;
        //}

        private readonly IGenericRepository<Student, int> _repo;
        public StudentsController(IGenericRepository<Student, int> repo)
        {
            _repo = repo;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageIndex, int pageSize = 3)
        {
            //return View(await _context.Students.ToListAsync());
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var students = _repo.Where();
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(x => x.LastName.Contains(searchString) ||
                     x.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            return View(await PagedListHelper<Student>.ToPagedListAsync(students, pageIndex ?? 1, pageSize));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.AsNoTracking()
            //    .Include(s => s.Enrollments)
            //        .ThenInclude(e => e.Course)
            //    .FirstOrDefaultAsync(m => m.ID == id);

            var student = await _repo.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Students/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(
        //    [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(student);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(student);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        //Log the error (uncomment ex variable name and write a log.
        //        ModelState.AddModelError("", "Unable to save changes. " +
        //            "Try again, and if the problem persists " +
        //            "see your system administrator.");
        //    }
        public async Task<IActionResult> Create(
            [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(student);
                await _repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _repo.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            var studentToUpdate = await _repo.FirstOrDefaultAsync(m => m.Id == id);

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                try
                {
                    _repo.Update(studentToUpdate);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    if (!await StudentExists(studentToUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentToUpdate);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id, bool saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _repo.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            if (saveChangesError)
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        //    var student = await _context.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }

        //    try
        //    {
        //        _context.Students.Remove(student);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (DbUpdateException /* ex */)
        //    {
        //        //Log the error (uncomment ex variable name and write a log.)
        //        return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
        //    }
        //}
            var student = await _repo.FindAsync(id);
            _repo.Remove(student);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> StudentExists(int id)
        {
            return _repo.AnyAsync(e => e.Id == id);
        }
    }
}
