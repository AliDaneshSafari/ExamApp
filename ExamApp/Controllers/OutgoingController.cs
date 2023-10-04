using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace ExamApp.Controllers
{
    public class OutgoingController : Controller
    {
        private readonly myDbContext _contxt;
        private readonly IWebHostEnvironment _he;
        public OutgoingController(myDbContext contxt, IWebHostEnvironment he)
        {
            _contxt = contxt;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_contxt.trackers.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.department = new SelectList(_contxt.department,"Id","Name");
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
                    lastIdTracker= trackers.Id;
                        if (FileUpload!= null)
                        {
                            AtachFile atachFile = new AtachFile();
                            var guid = Guid.NewGuid().ToString();
                            var passwandfile = Path.Combine(_he.WebRootPath + "/UploadFiles", guid + Path.GetFileName(FileUpload.FileName));
                            using (var streem = (new FileStream(passwandfile, FileMode.Create)))
                            {
                                FileUpload.CopyTo(streem);
                               atachFile.FilePath = guid + FileUpload.FileName;

                            }
                            atachFile.TrackerId= lastIdTracker;
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

        
}
}
