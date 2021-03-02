using CRUD_AGAIN.Data;
using CRUD_AGAIN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_AGAIN.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<Student> objlist = _db.Student;
            return View(objlist);
        }
        //get - create
        
        public IActionResult CreateStudent()
        {
            
            return View();
        }
        //post- create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent(Student obj)
        {
            if (ModelState.IsValid) {
                _db.Student.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }
        //Gt - edit
        
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Student.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //post- Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Student.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //Gt - Delete
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //post- Delete
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
           
                _db.Student.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            

        }

    }
}
