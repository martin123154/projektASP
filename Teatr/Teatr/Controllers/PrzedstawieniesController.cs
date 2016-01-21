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
    public class PrzedstawieniesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Przedstawienies
        public ActionResult Index()
        {
            var przedstawienia = db.Przedstawienia.Include(p => p.Scena);
            return View(przedstawienia.ToList());
        }

        // GET: Przedstawienies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedstawienie przedstawienie = db.Przedstawienia.Find(id);
            if (przedstawienie == null)
            {
                return HttpNotFound();
            }
            return View(przedstawienie);
        }

        // GET: Przedstawienies/Create
        public ActionResult Create()
        {
            ViewBag.scena_id = new SelectList(db.Sceny, "scena_id", "nazwa");
            return View();
        }

        // POST: Przedstawienies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "przedstawienie_id,tytul,data_rozp,data_zak,scena_id")] Przedstawienie przedstawienie)
        {
            if (ModelState.IsValid)
            {
                db.Przedstawienia.Add(przedstawienie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.scena_id = new SelectList(db.Sceny, "scena_id", "nazwa", przedstawienie.scena_id);
            return View(przedstawienie);
        }

        // GET: Przedstawienies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedstawienie przedstawienie = db.Przedstawienia.Find(id);
            if (przedstawienie == null)
            {
                return HttpNotFound();
            }
            ViewBag.scena_id = new SelectList(db.Sceny, "scena_id", "nazwa", przedstawienie.scena_id);
            return View(przedstawienie);
        }

        // POST: Przedstawienies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "przedstawienie_id,tytul,data_rozp,data_zak,scena_id")] Przedstawienie przedstawienie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przedstawienie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.scena_id = new SelectList(db.Sceny, "scena_id", "nazwa", przedstawienie.scena_id);
            return View(przedstawienie);
        }

        // GET: Przedstawienies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedstawienie przedstawienie = db.Przedstawienia.Find(id);
            if (przedstawienie == null)
            {
                return HttpNotFound();
            }
            return View(przedstawienie);
        }

        // POST: Przedstawienies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przedstawienie przedstawienie = db.Przedstawienia.Find(id);
            db.Przedstawienia.Remove(przedstawienie);
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
