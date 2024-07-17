using CodeFistMVc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace CodeFistMVc.Controllers
{
    public class HomeController : Controller
    {


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly StudentDBContext studentDB;
        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }

        public async Task<IActionResult> Index()
        {
           var stdData= await studentDB.Students.ToListAsync  ();
            return View(stdData);
        }
        public IActionResult create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(Student std)
        {
            if (ModelState.IsValid)
            {
                 await studentDB.Students.AddAsync(std);
                 await  studentDB.SaveChangesAsync();
                TempData["insert_success"] = "inserted....";
                return RedirectToAction("Index", "Home");
            }

            return View(std);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null|| studentDB.Students == null)
            {
               return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x=>x.Id==id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);

        }
        public async Task <IActionResult> Edit(int ? id)
        {
            var stdData = await studentDB.Students.FindAsync(id);
            return View(stdData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit( int? id, Student std )
        {
            if(id != std.Id)
            {
                NotFound();
            }
            if (ModelState.IsValid)
            {
                studentDB.Students.Update(std);
                await studentDB.SaveChangesAsync();
                TempData["update_success"] = "update....";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async  Task<IActionResult> Delete(int?  id )
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            } 
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
          
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await studentDB.Students.FindAsync(id);
            if ( stdData != null)
            {
                studentDB.Students.Remove(stdData);

            }
            await studentDB.SaveChangesAsync();
            TempData["Deleted_success"] = "Deleted....";
            return RedirectToAction("Index", "Home");
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
