using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMCS.Data.DataModel;

namespace EMCS.Web.UI.Internal.Controllers
{
    public class ReservationController : Controller
    {
        private EMCSEntities db = new EMCSEntities();

        // GET: Reservation
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Asset).Include(r => r.ReservationStatusSVT);
            return View(reservations.ToList());
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            ViewBag.AssetID = new SelectList(db.Assets, "ID", "SerialNumber");
            ViewBag.StatusID = new SelectList(db.ReservationStatusSVTs, "ID", "Description");
            return View();
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StartedOn,EndedOn,ReservationNumber,ReservedForID,CheckedOutOn,CheckedInOn,ExtensionEndsOn,CheckedOutByID,CheckedInByID,PickedUpByID,ReturnedByID,AssetID,StatusID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetID = new SelectList(db.Assets, "ID", "SerialNumber", reservation.AssetID);
            ViewBag.StatusID = new SelectList(db.ReservationStatusSVTs, "ID", "Description", reservation.StatusID);
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetID = new SelectList(db.Assets, "ID", "SerialNumber", reservation.AssetID);
            ViewBag.StatusID = new SelectList(db.ReservationStatusSVTs, "ID", "Description", reservation.StatusID);
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StartedOn,EndedOn,ReservationNumber,ReservedForID,CheckedOutOn,CheckedInOn,ExtensionEndsOn,CheckedOutByID,CheckedInByID,PickedUpByID,ReturnedByID,AssetID,StatusID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetID = new SelectList(db.Assets, "ID", "SerialNumber", reservation.AssetID);
            ViewBag.StatusID = new SelectList(db.ReservationStatusSVTs, "ID", "Description", reservation.StatusID);
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
