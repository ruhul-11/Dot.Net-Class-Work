using LibraryManagement.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace LibraryManagement.Controllers
{
    public class BorrowController : Controller
    {
        ProjectDbContext db = new ProjectDbContext();
        public ActionResult BorrowBook()
        {
            ViewBag.Books = new SelectList(db.Books, "BookId", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult BorrowBook(Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                borrow.IsBorrowed = true;
                db.BorrowList.Add(borrow);
                db.SaveChanges();
                FlashMessage.Confirmation("This book has been Borrowd.");
                return RedirectToAction("BorrowBook");

            }
            return View();
        }

        public JsonResult IsBookBorrowed(string memberNo)
        {
            var book = db.BorrowList.ToList();
            if (!book.Any(x => x.Member.MemberNo.ToLower() == memberNo.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBookById(int bookId)
        {
            var book = db.Books.FirstOrDefault(x=>x.BookId==bookId);
            return Json(book);
            
        }
    }
}