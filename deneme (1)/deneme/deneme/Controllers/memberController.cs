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
    public class memberController : Controller
    {
        private libraryProjectEntities db = new libraryProjectEntities();

        // GET: member
        public ActionResult Index()
        {
            var member = db.member.Include(m => m.address);
            return View(member.ToList());
        }

        [HttpPost]
        public ActionResult goster(String ad,int? parola)
        {
            if (ad == null || parola==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var author = (from i in db.member where i.name+" "+i.surname == ad.ToString() && i.memberNo==parola
                          select i).ToList();

            if (author != null && ModelState.IsValid)
            {
                return View(author);
            }
            else return View();


        }

        [HttpPost]
        public ActionResult memberbookyeni(String ad, int? parola)
        {
            if (ad == null || parola == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var author = (from i in db.member
                          where i.name + " " + i.surname == ad.ToString() && i.memberNo == parola
                          select i).ToList();

            if (author != null && ModelState.IsValid)
            {
                return View(author);
            }
            else return View();


        }

        // GET: member/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: member/Create
        public ActionResult Create()
        {
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber");
            return View();
        }
        public ActionResult member1()
        {

            return View();
        }
        public ActionResult memberyeni()
        {

            return View();
        }
        public ActionResult memberbook()
        {

            return View();
        }
        // POST: member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "memberNo,tc,name,surname,job,telephoneNumber,mailAddress,sex,addressNo")] member member)
        {
            if (ModelState.IsValid)
            {
                db.member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", member.addressNo);
            return View(member);
        }

        

        // GET: member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", member.addressNo);
            return View(member);
        }

        // POST: member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "memberNo,tc,name,surname,job,telephoneNumber,mailAddress,sex,addressNo")] member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.addressNo = new SelectList(db.address, "aId", "doorNumber", member.addressNo);
            return View(member);
        }

        // GET: member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            member member = db.member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }
        
        // POST: member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            member member = db.member.Find(id);
            db.member.Remove(member);
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
