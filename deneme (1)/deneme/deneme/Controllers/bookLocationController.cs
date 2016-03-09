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
    public class bookLocationController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: bookLocation
        public ActionResult Index()
        {
            var bookLocation = db.bookLocation.Include(b => b.book);
            return View(bookLocation.ToList());
        }

        // GET: bookLocation/Details/5
        [HttpPost]
        public ActionResult goster(int? yerara)
        {
            if (yerara == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //var a = (from i in db.bookLocation where i.barcodeNo == yerara select i).ToList();
            
            Object bookLocation = db.bookLocation.Where(n => n.barcodeNo == yerara).ToList();
            //var bookLocation = (from i in db.book select i).ToList();
            if (bookLocation != null)
            {
                return View(bookLocation);
            }
            else return View();

        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookLocation bookLocation = db.bookLocation.Find(id);
            if (bookLocation == null)
            {
                return HttpNotFound();
            }
            return View(bookLocation);
        }

        // GET: bookLocation/Create
        public ActionResult Create()
        {
            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn");
            return View();
        }

        // POST: bookLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "barcodeNo,floorNumber,hallNumber,shelfNumber,queueNumber")] bookLocation bookLocation)
        {
            if (ModelState.IsValid)
            {
                db.bookLocation.Add(bookLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn", bookLocation.barcodeNo);
            return View(bookLocation);
        }

        // GET: bookLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookLocation bookLocation = db.bookLocation.Find(id);
            if (bookLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn", bookLocation.barcodeNo);
            return View(bookLocation);
        }

        // POST: bookLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "barcodeNo,floorNumber,hallNumber,shelfNumber,queueNumber")] bookLocation bookLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.barcodeNo = new SelectList(db.book, "barcodeNo", "isbn", bookLocation.barcodeNo);
            return View(bookLocation);
        }

        // GET: bookLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookLocation bookLocation = db.bookLocation.Find(id);
            if (bookLocation == null)
            {
                return HttpNotFound();
            }
            return View(bookLocation);
        }

        // POST: bookLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookLocation bookLocation = db.bookLocation.Find(id);
            db.bookLocation.Remove(bookLocation);
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
