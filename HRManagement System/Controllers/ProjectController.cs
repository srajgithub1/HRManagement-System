using HRManagement_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var data = _db.projects.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project pro)
        {
            if(ModelState.IsValid)
            { 
            _db.Add(pro);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
            }
            return View(pro);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.projects.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Project pro)
        {

            if (ModelState.IsValid)
            {
                _db.projects.Update(pro);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(pro);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var prodb = _db.projects.Find(id);
            if (prodb == null)
            {
                return NotFound();
            }
            return View(prodb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.projects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.projects.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }

        [HttpGet]

        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var pro = await _db.projects.FirstOrDefaultAsync(m => m.Id == Id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }
    }
}
