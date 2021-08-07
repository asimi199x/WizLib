using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizlib_DataAccess.Data;
using Wizlib_Model.Models;

namespace Wizlib.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objList = _db.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id) // GET
        {
            Author obj = new Author();
            if(id == null)
            {
                // create new obj
                return View(obj);
            }
            else
            {
                obj = _db.Authors.FirstOrDefault(a => a.Author_Id == id);
                if (obj == null)
                    return NotFound();
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author author)
        {
            if (ModelState.IsValid)
            {
                if(author.Author_Id == 0)
                {
                    _db.Authors.Add(author);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Authors.Update(author);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.Authors.FirstOrDefault(a => a.Author_Id == id);
            _db.Authors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
