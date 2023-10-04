using ExamApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Controllers
{
    public class IncomingController : Controller
    {
        private readonly myDbContext _contxt;
        private readonly IWebHostEnvironment _he;
        public IncomingController(myDbContext contxt, IWebHostEnvironment he)
        {
            _contxt = contxt;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_contxt.trackers.Include(t => t.atachFiles).Where(t => t.ReciverId > 0).ToList());
        }
    }
}
