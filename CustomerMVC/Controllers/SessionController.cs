﻿using System;
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
    public class SessionController : Controller
    {
        private Assignment2Entities db = new Assignment2Entities();

        // GET: /Session/
        public ActionResult Index(string cinema, string searchString)
        {
            var locationList = new List<string>();

            var location = from d in db.Sessions orderby d.Location select d.Location;

            locationList.AddRange(location.Distinct());
            ViewBag.cinema = new SelectList(locationList);

            var movie = from s in db.Sessions select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                movie = movie.Where(s => s.Movie_Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(cinema))
            {
                movie = movie.Where(x => x.Location == cinema);
            }
            return View(movie);
            //var sessions = db.Sessions.Include(s => s.Movy);
            //return View(sessions.ToList());
        }

        // GET: /Session/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            Movies movies = db.Movies1.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            var storedata = new Booking
            {
            Movie_Title = session.Movie_Title,
            Movie_Time = session.Session_Time,
            Session_Time = session.Session_Day,
            Poster = movies.Poster
            };
            TempData["ConfirmBooking"] = storedata;
            TempData["Booking"] = storedata;
            return View(session);
        }

        // GET: /Session/Create
        public ActionResult Create()
        {
            ViewBag.Movie_ID = new SelectList(db.Movies1, "Movie_ID", "Movie_Title");
            return View();
        }

        // POST: /Session/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Session_ID,Movie_ID,Movie_Title,CineplexID,Location,Session_Time,Session_Day")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Movie_ID = new SelectList(db.Movies1, "Movie_ID", "Movie_Title", session.Movie_ID);
            return View(session);
        }

        // GET: /Session/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            ViewBag.Movie_ID = new SelectList(db.Movies1, "Movie_ID", "Movie_Title", session.Movie_ID);
            return View(session);
        }

        // POST: /Session/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Session_ID,Movie_ID,Movie_Title,CineplexID,Location,Session_Time,Session_Day")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Movie_ID = new SelectList(db.Movies1, "Movie_ID", "Movie_Title", session.Movie_ID);
            return View(session);
        }

        // GET: /Session/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: /Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);
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
