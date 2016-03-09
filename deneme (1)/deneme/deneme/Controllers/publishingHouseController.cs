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
    public class publishingHouseController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: publishingHouse
        public ActionResult Index()
        {
            var publishingHouse = db.publishingHouse.Include(p => p.address);
            return View(publishingHouse.ToList());
        }


        // GET: publishingHouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishingHouse publishingHouse = db.publishingHouse.Find(id);
            if (publishingHouse == null)
            {
                return HttpNotFound();
            }
            return View(publishingHouse);
        }
        public ActionResult yayineviniAra()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult yayineviniAra(int? yayinevi)
        {
            if (yayinevi == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var publishingHouse = db.publishingHouse.Where(n => n.pId == yayinevi).ToList();   
            if (publishingHouse != null)
            {
                return View(publishingHouse);
            }
            else return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        // GET: publishingHouse/Create
        public ActionResult Create()
        {
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber");
            return View();
        }

        // POST: publishingHouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pId,name,addressNo")] publishingHouse publishingHouse)
        {
            if (ModelState.IsValid)
            {
                db.publishingHouse.Add(publishingHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", publishingHouse.addressNo);
            return View(publishingHouse);
        }

        // GET: publishingHouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishingHouse publishingHouse = db.publishingHouse.Find(id);
            if (publishingHouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", publishingHouse.addressNo);
            return View(publishingHouse);
        }

        // POST: publishingHouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pId,name,addressNo")] publishingHouse publishingHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publishingHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", publishingHouse.addressNo);
            return View(publishingHouse);
        }

        // GET: publishingHouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishingHouse publishingHouse = db.publishingHouse.Find(id);
            if (publishingHouse == null)
            {
                return HttpNotFound();
            }
            return View(publishingHouse);
        }

        // POST: publishingHouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            publishingHouse publishingHouse = db.publishingHouse.Find(id);
            db.publishingHouse.Remove(publishingHouse);
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
