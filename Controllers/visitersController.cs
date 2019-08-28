using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTourist.Models;

namespace AppTourist.Controllers
{
    public class visitersController : Controller
    {
        private Model1 db = new Model1();

        // GET: visiters
        public ActionResult Index()
        {
            var visiter = db.visiter.Include(v => v.site).Include(v => v.visiteur);
            return View(visiter.ToList());
        }

        // GET: visiters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visiter visiter = db.visiter.Find(id);
            if (visiter == null)
            {
                return HttpNotFound();
            }
            return View(visiter);
        }

        // GET: visiters/Create
        public ActionResult Create()
        {
            ViewBag.IdSite = new SelectList(db.site, "Id", "Nom");
            ViewBag.IdVisiteur = new SelectList(db.visiteur, "Id", "Nom");
            return View();
        }

        // POST: visiters/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVisiteur,IdSite,Nbjour,DateVisite")] visiter visiter)
        {
            if (ModelState.IsValid)
            {
                db.visiter.Add(visiter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSite = new SelectList(db.site, "Id", "Nom", visiter.IdSite);
            ViewBag.IdVisiteur = new SelectList(db.visiteur, "Id", "Nom", visiter.IdVisiteur);
            return View(visiter);
        }

        // GET: visiters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visiter visiter = db.visiter.Find(id);
            if (visiter == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSite = new SelectList(db.site, "Id", "Nom", visiter.IdSite);
            ViewBag.IdVisiteur = new SelectList(db.visiteur, "Id", "Nom", visiter.IdVisiteur);
            return View(visiter);
        }

        // POST: visiters/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVisiteur,IdSite,Nbjour,DateVisite")] visiter visiter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSite = new SelectList(db.site, "Id", "Nom", visiter.IdSite);
            ViewBag.IdVisiteur = new SelectList(db.visiteur, "Id", "Nom", visiter.IdVisiteur);
            return View(visiter);
        }

        // GET: visiters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visiter visiter = db.visiter.Find(id);
            if (visiter == null)
            {
                return HttpNotFound();
            }
            return View(visiter);
        }

        // POST: visiters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visiter visiter = db.visiter.Find(id);
            db.visiter.Remove(visiter);
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
