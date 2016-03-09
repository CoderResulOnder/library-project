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
    public class categoryController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: category
        public ActionResult Index()
        {
            return View(db.category.ToList());
        }
        public ActionResult categoryAra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult categoryArabul(String categoryAdi)
        {
            if (categoryAdi == null)
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
            var category = (from i in db.category where i.name == categoryAdi select i).ToList();
            //Object book = db.book.Where(m => m.barcodeNo == no).ToList();
            if (category != null)
            {
                return View(category);
            }
            else return View();

        }


        // GET: category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: category/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult goster(String categoryname)
        {
            if (categoryname == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Object author = db.author.Where(m => m.tc == no).ToList();
            //
            var author = (from i in db.category where i.name == categoryname.ToString() select i).ToList();

            if (author != null && ModelState.IsValid)
            {
                return View(author);
            }
            else return View();


        }


        public ActionResult categoryKitap()
        {
            return View();
        }

        // POST: category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryId,name,explanation")] category category)
        {
            if (ModelState.IsValid)
            {
                db.category.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryId,name,explanation")] category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category category = db.category.Find(id);
            db.category.Remove(category);
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
