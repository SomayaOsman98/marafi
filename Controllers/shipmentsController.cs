using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using marafi1.Models;

namespace marafi1.Controllers
{
    public class shipmentsController : Controller
    {
        private marafiEntities1 db = new marafiEntities1();

        // GET: shipments
        public async Task<ActionResult> Index()
        {
            var shipment = db.shipment.Include(s => s.charging).Include(s => s.clients);
            return View(await shipment.ToListAsync());
        }

        // GET: shipments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipment shipment = await db.shipment.FindAsync(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: shipments/Create
        public ActionResult Create()
        {
            ViewBag.ID_charging = new SelectList(db.charging, "Id_charging", "name_charg");
            ViewBag.ID_man = new SelectList(db.clients, "ID_man", "name");
            return View();
        }

        // POST: shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ship,phone_recip,city_address,region,shipment_cont,quantity,ship_price,ID_man,ID_charging")] shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.shipment.Add(shipment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_charging = new SelectList(db.charging, "Id_charging", "name_charg", shipment.ID_charging);
            ViewBag.ID_man = new SelectList(db.clients, "ID_man", "name", shipment.ID_man);
            return View(shipment);
        }

        // GET: shipments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipment shipment = await db.shipment.FindAsync(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_charging = new SelectList(db.charging, "Id_charging", "name_charg", shipment.ID_charging);
            ViewBag.ID_man = new SelectList(db.clients, "ID_man", "name", shipment.ID_man);
            return View(shipment);
        }

        // POST: shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ship,phone_recip,city_address,region,shipment_cont,quantity,ship_price,ID_man,ID_charging")] shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_charging = new SelectList(db.charging, "Id_charging", "name_charg", shipment.ID_charging);
            ViewBag.ID_man = new SelectList(db.clients, "ID_man", "name", shipment.ID_man);
            return View(shipment);
        }

        // GET: shipments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shipment shipment = await db.shipment.FindAsync(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            shipment shipment = await db.shipment.FindAsync(id);
            db.shipment.Remove(shipment);
            await db.SaveChangesAsync();
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
