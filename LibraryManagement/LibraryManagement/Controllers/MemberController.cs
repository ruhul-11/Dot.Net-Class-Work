using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace LibraryManagement.Controllers
{
    public class MemberController : Controller
    {
        ProjectDbContext db = new ProjectDbContext();

        public ActionResult SaveMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveMember(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                FlashMessage.Confirmation("This member has been saved.");
                return RedirectToAction("SaveMember");

            }
            return View();
        }

        public JsonResult IsMemberExists(string memberNo)
        {
            var member = db.Members.ToList();
            if (!member.Any(x => x.MemberNo.ToLower() == memberNo.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}