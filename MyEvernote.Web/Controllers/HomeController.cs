using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.Web.ViewModel;
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
        private NoteManager noteManager = new NoteManager();
        private CategoryManager categoryManager = new CategoryManager();
        // GET: Home
        public ActionResult Index()
        {
            return View(noteManager.ListQueryable(a => a.IsDeleted == false).OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category cat = categoryManager.Find(x => x.ID == id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View("Index", cat.NvgNote.OrderByDescending(x => x.ModifiedOn).ToList());
        }

        public ActionResult MostLiked()
        {
            return View("Index", noteManager.ListQueryable(a=>a.IsDeleted==false).OrderByDescending(x => x.LikeCount).ToList());
        }

    }
}