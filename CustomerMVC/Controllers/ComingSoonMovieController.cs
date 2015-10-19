using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerMVC.Models;

namespace CustomerMVC.Controllers
{
    public class ComingSoonMovieController : Controller
    {
        private Assignment2Entities db = new Assignment2Entities();

        // GET: /ComingSoonMovie/
        public ActionResult Index()
        {
            return View(db.MovieComingSoons.ToList());
        }

        // GET: /ComingSoonMovie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieComingSoon moviecomingsoon = db.MovieComingSoons.Find(id);
            if (moviecomingsoon == null)
            {
                return HttpNotFound();
            }
            return View(moviecomingsoon);
        }

        // GET: /ComingSoonMovie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ComingSoonMovie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MovieComingSoonID,Title,ShortDescription,LongDescription,ImageUrl")] MovieComingSoon moviecomingsoon)
        {
            if (ModelState.IsValid)
            {
                db.MovieComingSoons.Add(moviecomingsoon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviecomingsoon);
        }

        // GET: /ComingSoonMovie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieComingSoon moviecomingsoon = db.MovieComingSoons.Find(id);
            if (moviecomingsoon == null)
            {
                return HttpNotFound();
            }
            return View(moviecomingsoon);
        }

        // POST: /ComingSoonMovie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MovieComingSoonID,Title,ShortDescription,LongDescription,ImageUrl")] MovieComingSoon moviecomingsoon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviecomingsoon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviecomingsoon);
        }

        // GET: /ComingSoonMovie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieComingSoon moviecomingsoon = db.MovieComingSoons.Find(id);
            if (moviecomingsoon == null)
            {
                return HttpNotFound();
            }
            return View(moviecomingsoon);
        }

        // POST: /ComingSoonMovie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieComingSoon moviecomingsoon = db.MovieComingSoons.Find(id);
            db.MovieComingSoons.Remove(moviecomingsoon);
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
