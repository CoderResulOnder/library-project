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
    [Authorize]
    public class employeeController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: employee
        public ActionResult Index()
        {
            var employee = db.employee.Include(e => e.address).Include(e => e.library);
            return View(employee.ToList());
        }
        public ActionResult employee1()
        {
                        return View();
        }
        // GET: employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employee/Create
        public ActionResult Create()
        {
            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber");
            ViewBag.kuNo = new SelectList(db.library, "kuId", "name");
            return View();
        }

        // POST: employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tc,employeNo,name,surname,job,jobToBeginDate,sex,addresNo,kuNo")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber", employee.addresNo);
            ViewBag.kuNo = new SelectList(db.library, "kuId", "name", employee.kuNo);
            return View(employee);
        }

        // GET: employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber", employee.addresNo);
            ViewBag.kuNo = new SelectList(db.library, "kuId", "name", employee.kuNo);
            return View(employee);
        }

        // POST: employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tc,employeNo,name,surname,job,jobToBeginDate,sex,addresNo,kuNo")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.addresNo = new SelectList(db.address, "aId", "doorNumber", employee.addresNo);
            ViewBag.kuNo = new SelectList(db.library, "kuId", "name", employee.kuNo);
            return View(employee);
        }

        // GET: employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employee.Find(id);
            db.employee.Remove(employee);
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
