using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using MyEvernote.Web.Models;

namespace MyEvernote.Web.Controllers
{
    public class NoteController : Controller
    {
        private NoteManager noteManager = new NoteManager();
        private CategoryManager catManager = new CategoryManager();
        private EvernoteUserManager userManager = new EvernoteUserManager();
        private LikedManager likedManager = new LikedManager();
        // GET: Note
        public ActionResult Index()
        {

            var notes = noteManager.ListQueryable(x => x.EvernoteUserID == SessionManager.User.ID && x.IsDeleted == false).Include("NvgCategory").Include("NvgUser").OrderByDescending(x => x.ModifiedOn);
            return View(notes.ToList());
        }

        public ActionResult MyLikedNotes()
        {
            var notes = likedManager.ListQueryable(x => x.EvernoteUserID == SessionManager.User.ID)
                .Include("NvgEverUser").Include("NvgNote")
                .Select(x => x.NvgNote).Include("NvgCategory").Include("NvgUser")
                .OrderByDescending(x => x.ModifiedOn);

            return View("Index", notes.ToList());
        }
        // GET: Note/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = noteManager.Find(x => x.ID == id.Value);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Note/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(catManager.List(x => x.IsDeleted == false), "ID", "Title");
            return View();
        }

        // POST: Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Note note)
        {
            ModelState.Remove("ModifiedUser");
            if (ModelState.IsValid)
            {
                note.NvgUser = SessionManager.User;
                noteManager.Insert(note);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(catManager.List(x => x.IsDeleted == false), "ID", "Title", note.CategoryID);
            return View(note);
        }

        // GET: Note/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = noteManager.Find(x => x.ID == id.Value && x.IsDeleted == false);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(catManager.List(x => x.IsDeleted == false), "ID", "Title", note.CategoryID);
            return View(note);
        }

        // POST: Note/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Note note)
        {
            ModelState.Remove("ModifiedUser");
            if (ModelState.IsValid)
            {
                Note dbnote = noteManager.Find(x => x.ID == note.ID && x.IsDeleted == false);
                dbnote.CategoryID = note.CategoryID;
                dbnote.Text = note.Text;
                dbnote.Title = note.Title;
                noteManager.Update(dbnote);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(catManager.List(x => x.IsDeleted == false), "ID", "Title", note.CategoryID);
            return View(note);
        }

        // GET: Note/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = noteManager.Find(x => x.ID == id.Value && x.IsDeleted == false);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Note/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = noteManager.Find(x => x.ID == id && x.IsDeleted == false);
            noteManager.Delete(note);
            return RedirectToAction("Index");
        }

    }
}
