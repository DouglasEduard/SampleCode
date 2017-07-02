using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prospectivos.Models;

namespace Prospectivos.Controllers
{
    public class ProspectivoContatoController : Controller
    {
        private ModeloDados db = new ModeloDados();

        // GET: ProspectivoContato
        public async Task<ActionResult> Index()
        {
            var prospectivoContato = db.ProspectivoContato.Include(p => p.Prospectivo);
            return View(await prospectivoContato.ToListAsync());
        }

        // GET: ProspectivoContato/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProspectivoContato prospectivoContato = await db.ProspectivoContato.FindAsync(id);
            if (prospectivoContato == null)
            {
                return HttpNotFound();
            }
            return View(prospectivoContato);
        }

        // GET: ProspectivoContato/Create
        public ActionResult Create(int? id)
        {
            if (id!=null)
                ViewBag.ProspectivoCod = new SelectList(db.Prospectivo.Where(c => c.ProspectivoCod == id), "ProspectivoCod", "ProspectivoNome");
            else
                ViewBag.ProspectivoCod = new SelectList(db.Prospectivo, "ProspectivoCod", "ProspectivoNome");

            return View();
        }

        // POST: ProspectivoContato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProspectivoContatoId,ProspectivoCod,ProspectivoContatoData,ProspectivoContatoDetalhes,ProspectivoContatoGestaoEscolas,ProspectivoContatoBiblioteca,ProspectivoContatoCursosLivres,ProspectivoContatoAcervo")] ProspectivoContato prospectivoContato)
        {
            if (ModelState.IsValid)
            {
                prospectivoContato.ProspectivoContatoData = System.DateTime.Now;
                db.ProspectivoContato.Add(prospectivoContato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProspectivoCod = new SelectList(db.Prospectivo, "ProspectivoCod", "ProspectivoNome", prospectivoContato.ProspectivoCod);
            return View(prospectivoContato);
        }

        // GET: ProspectivoContato/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProspectivoContato prospectivoContato = await db.ProspectivoContato.FindAsync(id);
            if (prospectivoContato == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProspectivoCod = new SelectList(db.Prospectivo, "ProspectivoCod", "ProspectivoNome", prospectivoContato.ProspectivoCod);
            return View(prospectivoContato);
        }

        // POST: ProspectivoContato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProspectivoContatoId,ProspectivoCod,ProspectivoContatoData,ProspectivoContatoDetalhes,ProspectivoContatoGestaoEscolas,ProspectivoContatoBiblioteca,ProspectivoContatoCursosLivres,ProspectivoContatoAcervo")] ProspectivoContato prospectivoContato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prospectivoContato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProspectivoCod = new SelectList(db.Prospectivo, "ProspectivoCod", "ProspectivoNome", prospectivoContato.ProspectivoCod);
            return View(prospectivoContato);
        }

        // GET: ProspectivoContato/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProspectivoContato prospectivoContato = await db.ProspectivoContato.FindAsync(id);
            if (prospectivoContato == null)
            {
                return HttpNotFound();
            }
            return View(prospectivoContato);
        }

        // POST: ProspectivoContato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProspectivoContato prospectivoContato = await db.ProspectivoContato.FindAsync(id);
            db.ProspectivoContato.Remove(prospectivoContato);
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
