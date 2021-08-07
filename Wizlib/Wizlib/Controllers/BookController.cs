using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wizlib_DataAccess.Data;
using Wizlib_Model.Models;
using Wizlib_Model.ViewModels;

namespace Wizlib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Books.Include(u => u.Publisher).ToList();

            #region sử dụng explicit loading
            /*foreach(var obj in objList)
            {
                //obj.Publisher = _db.Publishers.FirstOrDefault(a => a.Publisher_Id == obj.Publisher_Id);
                _db.Entry(obj).Reference(u => u.Publisher).Load();
                
            }*/
            #endregion


            return View(objList);
        }

        public IActionResult Upsert(int? id) // GET
        {
            BookPublisherVM BPVM = new BookPublisherVM();
            BPVM.Publishers = _db.Publishers.Select(i => new SelectListItem { 
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            BPVM.Book = new Book();
            if(id == null)
            {
                return View(BPVM);
            }
            BPVM.Book = _db.Books.FirstOrDefault(i => i.Book_Id == id);
            return View(BPVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookPublisherVM BPVM)
        {
            if (ModelState.IsValid)
            {
                if(BPVM.Book.Book_Id == 0)
                {
                    _db.Books.Add(BPVM.Book);
                }
                else
                {
                    _db.Books.Update(BPVM.Book);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(BPVM);
        }

        public IActionResult Details(int? id) // GET
        {
            BookPublisherVM BPVM = new BookPublisherVM();
            if (id == null)
            {
                return View(BPVM);
            }
            BPVM.Book = _db.Books.Include(u=>u.BookDetail).FirstOrDefault(i => i.Book_Id == id);
            //BPVM.Book.BookDetail = _db.BookDetails.FirstOrDefault(i => i.BookDetail_Id == BPVM.Book.BookDetail_Id);
            return View(BPVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookPublisherVM BPVM)
        {
                if (BPVM.Book.BookDetail.BookDetail_Id== 0)
                {
                    _db.BookDetails.Add(BPVM.Book.BookDetail);
                    _db.SaveChanges();
                    var BookFromDb = _db.Books.FirstOrDefault(a => a.Book_Id == BPVM.Book.Book_Id);
                    BookFromDb.BookDetail_Id = BPVM.Book.BookDetail.BookDetail_Id;
                    _db.SaveChanges();
                }
                else
                {
                    _db.BookDetails.Update(BPVM.Book.BookDetail);
                    _db.SaveChanges();
                }
               
                //BookFromDb.BookDetail = BPVM.Book.BookDetail;
                //_db.Books.Update(BookFromDb);
                
                return RedirectToAction(nameof(Index));

        }


        public IActionResult Delete(int id)
        {
            var obj = _db.Books.FirstOrDefault(a => a.Book_Id == id);
            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new BookAuthorVM
            {
                BookAuthorList = _db.BookAuthors.Include(u => u.Author).Include(u => u.Book).Where(u => u.Book_Id == id).ToList(),
                BookAuthor = new BookAuthor
                {
                    Book_Id = id
                },
                Book = _db.Books.FirstOrDefault(u => u.Book_Id == id),
            };
            return
        }
        public IActionResult PlayGround()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
