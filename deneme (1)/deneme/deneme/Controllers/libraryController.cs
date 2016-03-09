using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using deneme.Models;

namespace deneme.Controllers
{
    public class libraryController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: library
        public ActionResult Index()
        {
            var library = db.library.Include(l => l.address);
            return View(library.ToList());
        }
        public ActionResult kutuphaneBilgiEdin()
        {
            var library = db.library.Include(l => l.address);
            return View(library.ToList());
        }
        public ActionResult member2()
        {

            return View();
        }

        // GET: library/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            library library = db.library.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: library/Create
        public ActionResult Create()
        {
            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber");
            return View();
        }

        // POST: library/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kuId,name,constructionDate,workTime,addresNo")] library library)
        {
            if (ModelState.IsValid)
            {
                db.library.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber", library.addresNo);
            return View(library);
        }

        // GET: library/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            library library = db.library.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber", library.addresNo);
            return View(library);
        }

        // POST: library/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kuId,name,constructionDate,workTime,addresNo")] library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber", library.addresNo);
            return View(library);
        }

        // GET: library/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            library library = db.library.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            library library = db.library.Find(id);
            db.library.Remove(library);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
