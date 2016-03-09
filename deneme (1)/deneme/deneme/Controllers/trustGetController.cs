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
    public class trustGetController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: trustGet
        public ActionResult Index()
        {
            var trustGet = db.trustGet.Include(t => t.book).Include(t => t.member);
            return View(trustGet.ToList());
        }

        // GET: trustGet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trustGet trustGet = db.trustGet.Find(id);
            if (trustGet == null)
            {
                return HttpNotFound();
            }
            return View(trustGet);
        }

        // GET: trustGet/Create
        public ActionResult Create()
        {
            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn");
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc");
            return View();
        }

        // POST: trustGet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberNo,barcodeNo,comment,getDate,returnDate,dept,trustId")] trustGet trustGet)
        {
            if (ModelState.IsValid)
            {
                db.trustGet.Add(trustGet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn", trustGet.barcodeNo);
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc", trustGet.memberNo);
            return View(trustGet);
        }

        // GET: trustGet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trustGet trustGet = db.trustGet.Find(id);
            if (trustGet == null)
            {
                return HttpNotFound();
            }
            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn", trustGet.barcodeNo);
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc", trustGet.memberNo);
            return View(trustGet);
        }

        // POST: trustGet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memberNo,barcodeNo,comment,getDate,returnDate,dept,trustId")] trustGet trustGet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trustGet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn", trustGet.barcodeNo);
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc", trustGet.memberNo);
            return View(trustGet);
        }

        // GET: trustGet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trustGet trustGet = db.trustGet.Find(id);
            if (trustGet == null)
            {
                return HttpNotFound();
            }
            return View(trustGet);
        }

        // POST: trustGet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trustGet trustGet = db.trustGet.Find(id);
            db.trustGet.Remove(trustGet);
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
