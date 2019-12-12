using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        ProjectDbContext db = new ProjectDbContext();

        public ActionResult SaveBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                FlashMessage.Confirmation("This book has been saved.");
                return RedirectToAction("SaveBook");

            }
            return View();
        }

        public JsonResult IsTitleExists(string title)
        {
            var book = db.Books.ToList();
            if (!book.Any(x => x.Title.ToLower() == title.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}