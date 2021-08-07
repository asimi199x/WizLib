using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizlib_DataAccess.Data;
using Wizlib_Model.Models;

namespace Wizlib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objList = _db.Categories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id) // GET
        {
            Category obj = new Category();
            if(id == null)
            {
                // create new obj
                return View(obj);
            }
            else
            {
                obj = _db.Categories.FirstOrDefault(a => a.Category_Id == id);
                if (obj == null)
                    return NotFound();
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.Category_Id == 0)
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Categories.Update(category);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        /*public IActionResult Delete(int id)
        {
            var obj = _db.Categories.FirstOrDefault(a => a.Category_Id == id);
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }*/

        public IActionResult Delete(int id)
        {
            Category obj = _db.Categories.FirstOrDefault(a => a.Category_Id == id);
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int? model, bool isOK)
        {
            if (model == null || !isOK)
                return RedirectToAction(nameof(Index));
            Category obj = _db.Categories.FirstOrDefault(a => a.Category_Id == model);
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple(int count)
        {
            for(int i = 1; i <= count; i++)
            {
                _db.Categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }  
        public IActionResult RemoveMultiple(int count)
        {
            IEnumerable<Category> catList = _db.Categories.OrderByDescending(a => a.Category_Id).Take(count).ToList();
            _db.RemoveRange(catList); 
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
