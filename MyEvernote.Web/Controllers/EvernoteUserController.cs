using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEvernote.BusinessLayer;
using MyEvernote.Entities;

namespace MyEvernote.Web.Controllers
{
    public class EvernoteUserController : Controller
    {
        private EvernoteUserManager userManager = new EvernoteUserManager();

        // GET: EvernoteUsers
        public ActionResult Index()
        {
            return View(userManager.ListQueryable());
        }

        // GET: EvernoteUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvernoteUser evernoteUser = userManager.Find(x => x.ID == id.Value);
            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            return View(evernoteUser);
        }

        // GET: EvernoteUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvernoteUser evernoteUser = userManager.Find(x=>x.ID==id.Value);
            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            return View(evernoteUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EvernoteUser evernoteUser)
        {
            ModelState.Remove("ModifiedUser");
            ModelState.Remove("Password");
            ModelState.Remove("ActivateGuid");
            ModelState.Remove("İmagesFileName");
            if (ModelState.IsValid)
            {
                EvernoteUser user = userManager.Find(x => x.ID == evernoteUser.ID);
                user.isAdmin = evernoteUser.isAdmin;
                userManager.Update(user);
                return RedirectToAction("Index");
            }
            return View(evernoteUser);
        }

        // GET: EvernoteUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvernoteUser evernoteUser = userManager.Find(x => x.ID == id.Value);
            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            userManager.Delete(evernoteUser);
            return RedirectToAction("Index");
        }

     
    }
}
