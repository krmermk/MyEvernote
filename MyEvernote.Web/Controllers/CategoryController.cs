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
    public class CategoryController : Controller
    {
        private CategoryManager catManager = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
            return View(catManager.List(x => x.IsDeleted == false));
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = catManager.Find(x => x.ID == id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            ModelState.Remove("ModifiedUser");
            if (ModelState.IsValid)
            {
                catManager.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = catManager.Find(x => x.ID == id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            ModelState.Remove("ModifiedUser");
            if (ModelState.IsValid)
            {
                Category cat = catManager.Find(x => x.ID == category.ID && x.IsDeleted == false);
                cat.Title = category.Title;
                cat.Description = category.Description;
                catManager.Update(cat);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = catManager.Find(x => x.ID == id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }

            catManager.Delete(category);
            return RedirectToAction("Index", "Category");
            //return View(category);
        }


    }
}
