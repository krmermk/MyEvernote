using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //if (TempData["cm"]!=null)
            //{
            //    return View(TempData["cm"] as List<Note>);
            //}
            NoteManager nm = new NoteManager();

            //return View(nm.GetAllNote().OrderByDescending(x=>x.ModifiedOn));
            return View(nm.GetAllNotes().OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View("Index", cat.NvgNote.OrderByDescending(x=>x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            NoteManager nm = new NoteManager();
            return View("Index",nm.GetAllNotes().OrderByDescending(x => x.LikeCount).ToList());
        }


    }
}