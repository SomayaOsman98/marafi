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
    public class follow_deliverController : Controller
    {
        private marafiEntities1 db = new marafiEntities1();

        // GET: follow_deliver
        public async Task<ActionResult> Index()
        {
            return View(await db.follow_deliver.ToListAsync());
        }

        // GET: follow_deliver/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            follow_deliver follow_deliver = await db.follow_deliver.FindAsync(id);
            if (follow_deliver == null)
            {
                return HttpNotFound();
            }
            return View(follow_deliver);
        }

        // GET: follow_deliver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: follow_deliver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_charging,name_chg,quantity_charg,type_charging,coming_from,date,sender,recip")] follow_deliver follow_deliver)
        {
            if (ModelState.IsValid)
            {
                db.follow_deliver.Add(follow_deliver);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(follow_deliver);
        }

        // GET: follow_deliver/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            follow_deliver follow_deliver = await db.follow_deliver.FindAsync(id);
            if (follow_deliver == null)
            {
                return HttpNotFound();
            }
            return View(follow_deliver);
        }

        // POST: follow_deliver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_charging,name_chg,quantity_charg,type_charging,coming_from,date,sender,recip")] follow_deliver follow_deliver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(follow_deliver).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(follow_deliver);
        }

        // GET: follow_deliver/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            follow_deliver follow_deliver = await db.follow_deliver.FindAsync(id);
            if (follow_deliver == null)
            {
                return HttpNotFound();
            }
            return View(follow_deliver);
        }

        // POST: follow_deliver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            follow_deliver follow_deliver = await db.follow_deliver.FindAsync(id);
            db.follow_deliver.Remove(follow_deliver);
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
