using HRManagement_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement_System.Controllers
{
    public class EmployeeController : Controller
    {
        private  ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
       
        [HttpGet]

        public IActionResult Details(int? Id)
        {
            if(Id==null)
            {
                return NotFound();
            }
            var employee =  _db.employees.FirstOrDefault(m => m.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                _db.Add(emp);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        
        public IActionResult Index()
        {
            var data = _db.employees.ToList();

            return View(data);
        }

       [HttpGet]
        public IActionResult Edit(int?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.employees.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
           
            if (ModelState.IsValid)
            {
                _db.employees.Update(emp);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        [HttpGet]
        public IActionResult Delete(int?id)
        {
            if(id==null||id==0)
            {
                return NotFound();
            }
            var empdb = _db.employees.Find(id);
            if(empdb==null)
            {
                return NotFound();
            }
            return View(empdb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int?id)
        {
            var obj = _db.employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}
