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
using Newtonsoft.Json;

namespace marafi1.Controllers
{
    public class clientsController : Controller
    {
        private marafiEntities1 db = new marafiEntities1();
        private marafiEntities1 MN = new marafiEntities1();
      

        // GET: clients
        public async Task<ActionResult> Index()
        {
            var clients = db.clients.Include(c => c.Company);
            return View(await clients.ToListAsync());
        }
        [HttpGet]
        public JsonResult GetItemUnitPrice(int? itemId)
        {
            string UnitPrice = MN.Company.Single(model => model.ID_comp == itemId).address;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Action(int id)
        {
            List<Company> result = db.Company.Where(c => c.ID_comp == id).Select(c => c).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients clients = await db.clients.FindAsync(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // GET: clients/Create
        public ActionResult Create()
        {
            ViewBag.ID_comp = new SelectList(db.Company, "ID_comp", "name_comp");
            return View();
        }

        // POST: clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_man,name,address,value,phone,sender,ID_comp")] clients clients)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(clients);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_comp = new SelectList(db.Company, "ID_comp", "name_comp", clients.ID_comp);
          
            return View(clients);
        }

        // GET: clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients clients = await db.clients.FindAsync(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_comp = new SelectList(db.Company, "ID_comp", "name_comp", clients.ID_comp);
          
            return View(clients);
        }

        // POST: clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_man,name,address,value,phone,sender,ID_comp")] clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_comp = new SelectList(db.Company, "ID_comp", "name_comp", clients.ID_comp);
          
            return View(clients);
        }

        // GET: clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients clients = await db.clients.FindAsync(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            clients clients = await db.clients.FindAsync(id);
            db.clients.Remove(clients);
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
