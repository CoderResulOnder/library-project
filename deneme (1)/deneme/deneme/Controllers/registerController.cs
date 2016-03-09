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
    public class registerController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: register
        public ActionResult Index()
        {
            var register = db.register.Include(r => r.library).Include(r => r.member);
            return View(register.ToList());
        }

        // GET: register/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.register.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: register/Create
        public ActionResult Create()
        {
            ViewBag.kuId = new SelectList(db.library, "kuId", "name");
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc");
            return View();
        }

        // POST: register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kuId,memberNo,memberRegisterDate,registerId")] register register)
        {
            if (ModelState.IsValid)
            {
                db.register.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kuId = new SelectList(db.library, "kuId", "name", register.kuId);
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc", register.memberNo);
            return View(register);
        }

        // GET: register/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.register.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            ViewBag.kuId = new SelectList(db.library, "kuId", "name", register.kuId);
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc", register.memberNo);
            return View(register);
        }

        // POST: register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kuId,memberNo,memberRegisterDate,registerId")] register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kuId = new SelectList(db.library, "kuId", "name", register.kuId);
            ViewBag.memberNo = new SelectList(db.member, "memberNo", "tc", register.memberNo);
            return View(register);
        }

        // GET: register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.register.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            register register = db.register.Find(id);
            db.register.Remove(register);
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
