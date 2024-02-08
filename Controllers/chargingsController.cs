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
    public class chargingsController : Controller
    {
        private marafiEntities1 db = new marafiEntities1();

        // GET: chargings
        public async Task<ActionResult> Index()
        {
            return View(await db.charging.ToListAsync());
        }

        // GET: chargings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charging charging = await db.charging.FindAsync(id);
            if (charging == null)
            {
                return HttpNotFound();
            }
            return View(charging);
        }

        // GET: chargings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: chargings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_charging,name_charg")] charging charging)
        {
            if (ModelState.IsValid)
            {
                db.charging.Add(charging);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(charging);
        }

        // GET: chargings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charging charging = await db.charging.FindAsync(id);
            if (charging == null)
            {
                return HttpNotFound();
            }
            return View(charging);
        }

        // POST: chargings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_charging,name_charg")] charging charging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charging).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(charging);
        }

        // GET: chargings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charging charging = await db.charging.FindAsync(id);
            if (charging == null)
            {
                return HttpNotFound();
            }
            return View(charging);
        }

        // POST: chargings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            charging charging = await db.charging.FindAsync(id);
            db.charging.Remove(charging);
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
