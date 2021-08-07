using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizlib_DataAccess.Data;
using Wizlib_Model.Models;

namespace Wizlib.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objList = _db.Publishers.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id) // GET
        {
            Publisher obj = new Publisher();
            if(id == null)
            {
                // create new obj
                return View(obj);
            }
            else
            {
                obj = _db.Publishers.FirstOrDefault(a => a.Publisher_Id == id);
                if (obj == null)
                    return NotFound();
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if(publisher.Publisher_Id == 0)
                {
                    _db.Publishers.Add(publisher);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Publishers.Update(publisher);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
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
            Publisher obj = _db.Publishers.FirstOrDefault(a => a.Publisher_Id == id);
            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
