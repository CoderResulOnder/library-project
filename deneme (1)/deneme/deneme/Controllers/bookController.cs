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
    public class bookController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: book
        public ActionResult Index()
        {
            var book = db.book.Include(b => b.library).Include(b => b.publishingHouse);
            return View(book.ToList());
        }
        public ActionResult tumKitaplar()
        {
            var book = db.book.Include(b => b.library).Include(b => b.publishingHouse);
            return View(book.ToList());
        }
        public ActionResult kitapAra()
        {
            return View();
        }
        public ActionResult kitapAraYayin()
        {
            return View();
        }
        public ActionResult gecis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult kitapAra(int? no)
        {
            if (no==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Object book = db.book.Where(m=>m.barcodeNo == no).ToList();
            if (book != null) return View(book);
            else return View();
          
        }
        [HttpPost]
        public ActionResult goster(String no)
        {
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var book = (from i in db.book
            //            join k in db.author
            //            join l in db.write
            //            on i.bookLocation equals k.barcodeNo
            //            where  i.name==no.ToString()  select i).ToList();
            
            //
            //
            var book = (from i in db.book where i.name == no.ToString() select i).ToList();
            //Object book = db.book.Where(m => m.barcodeNo == no).ToList();
            if (book != null)
            {
                return View(book);
            }
            else return View();

        }
        [HttpPost]
        public ActionResult gosteri(String no)
        {
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var book = (from i in db.book
            //            join k in db.author
            //            join l in db.write
            //            on i.bookLocation equals k.barcodeNo
            //            where  i.name==no.ToString()  select i).ToList();

            //
            //
            var book = (from i in db.book where i.name == no.ToString() select i).ToList();
            //Object book = db.book.Where(m => m.barcodeNo == no).ToList();
            if (book != null)
            {
                return View(book);
            }
            else return View();

        }
        // GET: book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
       
        // GET: book/Create
        public ActionResult Create()
        {
            ViewBag.libraryNo = new SelectList(db.library, "kuId", "name");
            ViewBag.publishingHouseNo = new SelectList(db.publishingHouse, "pId", "name");
            return View();
        }

        // POST: book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "barcodeNo,isbn,name,numberInformation,pageInformation,libraryNo,publishingHouseNo")] book book)
        {
            if (ModelState.IsValid)
            {
                db.book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.libraryNo = new SelectList(db.library, "kuId", "name", book.libraryNo);
            ViewBag.publishingHouseNo = new SelectList(db.publishingHouse, "pId", "name", book.publishingHouseNo);
            return View(book);
        }

        // GET: book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.libraryNo = new SelectList(db.library, "kuId", "name", book.libraryNo);
            ViewBag.publishingHouseNo = new SelectList(db.publishingHouse, "pId", "name", book.publishingHouseNo);
            return View(book);
        }

        // POST: book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "barcodeNo,isbn,name,numberInformation,pageInformation,libraryNo,publishingHouseNo")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.libraryNo = new SelectList(db.library, "kuId", "name", book.libraryNo);
            ViewBag.publishingHouseNo = new SelectList(db.publishingHouse, "pId", "name", book.publishingHouseNo);
            return View(book);
        }

        // GET: book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.book.Find(id);
            db.book.Remove(book);
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
