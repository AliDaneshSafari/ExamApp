using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Controllers
{
    public class ArchiveController : Controller
    {
        private readonly myDbContext _contxt;
        private readonly IWebHostEnvironment _he;
        public ArchiveController(myDbContext contxt, IWebHostEnvironment he)
        {
            _contxt = contxt;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_contxt.trackers.Include(t => t.atachFiles).Include(a=>a.Department).Where(t => t.ReciverId > 0).ToList());
          
        }
        public IActionResult Create()
        {
            ViewBag.department = new SelectList(_contxt.department, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Trackers trackers, IFormFile FileUpload)
        {
            try
            {
                var lastIdTracker = 0;
                if (trackers != null)
                {
                    trackers.CreateDate = DateTime.Now;
                    _contxt.Add(trackers);
                    _contxt.SaveChanges();
                    lastIdTracker = trackers.Id;
                    if (FileUpload != null)
                    {
                        AtachFile atachFile = new AtachFile();
                        var guid = Guid.NewGuid().ToString();
                        var passwandfile = Path.Combine(_he.WebRootPath + "/UploadFiles", guid + Path.GetFileName(FileUpload.FileName));
                        using (var streem = (new FileStream(passwandfile, FileMode.Create)))
                        {
                            FileUpload.CopyTo(streem);
                            atachFile.FilePath = guid + FileUpload.FileName;

                        }
                        atachFile.TrackerId = lastIdTracker;
                        _contxt.atachFiles.Add(atachFile);
                        _contxt.SaveChanges();
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                TempData["messages"] = "faild try agin" + ex;

            }
            return View();

        }

        public IActionResult Approve(int id)
        {
            var data = _contxt.trackers.Find(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignRemark")] Trackers trackers)
        {
            if (id != trackers.Id)
            {
                return NotFound();
            }

           
                try
                {
                    _contxt.Update(trackers);
                    await _contxt.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
           
           
        }

    }
}
