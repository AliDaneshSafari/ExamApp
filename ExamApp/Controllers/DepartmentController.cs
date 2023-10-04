using ExamApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly myDbContext _contxt;
        public DepartmentController(myDbContext contxt)
        {
            _contxt = contxt;
        }

        public ActionResult Index()
        {
            return View(_contxt.department.ToList());
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            _contxt.Add(department);
             await _contxt.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: DepartmentController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _contxt.department == null)
            {
                return NotFound();
            }

            var acountType = await _contxt.department.FindAsync(id);
            if (acountType == null)
            {
                return NotFound();
            }
            return PartialView(acountType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contxt.Update(department);
                    await _contxt.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Admin/AcountTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _contxt.department == null)
            {
                return NotFound();
            }

            var acountType = await _contxt.department
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acountType == null)
            {
                return NotFound();
            }

            return PartialView(acountType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var acountType = await _contxt.department.FindAsync(id);

            if (acountType != null)
            {
                _contxt.department.Remove(acountType);
            }

            await _contxt.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
