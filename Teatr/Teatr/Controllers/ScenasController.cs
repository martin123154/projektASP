using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teatr.Models;

namespace Teatr.Controllers
{
    [Authorize]
    public class ScenasController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Scenas
        public ActionResult Index()
        {
            return View(db.Sceny.ToList());
        }

        // GET: Scenas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scena scena = db.Sceny.Find(id);
            if (scena == null)
            {
                return HttpNotFound();
            }
            return View(scena);
        }

        // GET: Scenas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scenas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scena_id,nazwa,wielkosc,numer")] Scena scena)
        {
            if (ModelState.IsValid)
            {
                db.Sceny.Add(scena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scena);
        }

        // GET: Scenas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scena scena = db.Sceny.Find(id);
            if (scena == null)
            {
                return HttpNotFound();
            }
            return View(scena);
        }

        // POST: Scenas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scena_id,nazwa,wielkosc,numer")] Scena scena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scena);
        }

        // GET: Scenas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scena scena = db.Sceny.Find(id);
            if (scena == null)
            {
                return HttpNotFound();
            }
            return View(scena);
        }

        // POST: Scenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scena scena = db.Sceny.Find(id);
            db.Sceny.Remove(scena);
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
