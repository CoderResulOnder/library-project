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
    public class authorController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: author
        public ActionResult Index()
        {
            var author = db.author.Include(a => a.address);
            return View(author.ToList());
        }
        public ActionResult yazarKitap()
        {
            return View();
        }

        // GET: author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }
        [HttpPost]
        public ActionResult goster(String no)
        {
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Object author = db.author.Where(m => m.tc == no).ToList();
            //
            var author = (from i in db.author where i.name == no.ToString() select i).ToList();
            
            if (author  != null && ModelState.IsValid)
            {
                return View(author);
            }
            else return View(); 
             

        }



        [HttpPost]
        public ActionResult gosteryeni(String authorname)
        {
            if (authorname == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Object author = db.author.Where(m => m.tc == no).ToList();
            //
            var author = (from i in db.author where i.name+" "+i.surname ==authorname.ToString() select i).ToList();

            if (author != null && ModelState.IsValid)
            {
                return View(author);
            }
            else return View();


        }



        // GET: author/Create
        public ActionResult Create()
        {
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber");
            return View();
        }

        // POST: author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tc,name,surname,authorAboutInformation,addressNo")] author author)
        {
            if (ModelState.IsValid)
            {
                db.author.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", author.addressNo);
            return View(author);
        }

        // GET: author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", author.addressNo);
            return View(author);
        }

        // POST: author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tc,name,surname,authorAboutInformation,addressNo")] author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", author.addressNo);
            return View(author);
        }

        // GET: author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            author author = db.author.Find(id);
            db.author.Remove(author);
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
