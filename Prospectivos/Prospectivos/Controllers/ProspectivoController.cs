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
    public class ProspectivoController : Controller
    {
        private ModeloDados db = new ModeloDados();

        // GET: Prospectivo
        public async Task<ActionResult> Index()
        {
            return View(await db.Prospectivo.ToListAsync());
        }

        // GET: Prospectivo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Prospectivo prospectivo = await db.Prospectivo.FindAsync(id);            

            prospectivo.Contatos = new List<ProspectivoContato>();

            var prospectivoContato = db.ProspectivoContato.Include(p => p.Prospectivo)
                                                                      .Where(c => c.ProspectivoCod == id)
                                                                      .OrderByDescending(o => o.ProspectivoContatoData);
            prospectivo.Contatos = prospectivoContato.ToList();

            if (prospectivo == null)
            {
                return HttpNotFound();
            }
            return View(prospectivo);
        }

        // GET: Prospectivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prospectivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProspectivoCod,ProspectivoNome,ProspectivoContato,ProspectivoTelefone")] Prospectivo prospectivo)
        {
            if (ModelState.IsValid)
            {
                db.Prospectivo.Add(prospectivo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(prospectivo);
        }

        // GET: Prospectivo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospectivo prospectivo = await db.Prospectivo.FindAsync(id);
            if (prospectivo == null)
            {
                return HttpNotFound();
            }
            return View(prospectivo);
        }

        // POST: Prospectivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProspectivoCod,ProspectivoNome,ProspectivoContato,ProspectivoTelefone")] Prospectivo prospectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prospectivo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prospectivo);
        }

        // GET: Prospectivo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prospectivo prospectivo = await db.Prospectivo.FindAsync(id);
            if (prospectivo == null)
            {
                return HttpNotFound();
            }
            return View(prospectivo);
        }

        // POST: Prospectivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prospectivo prospectivo = await db.Prospectivo.FindAsync(id);
            db.Prospectivo.Remove(prospectivo);
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

        public ActionResult CreateNewContact(int? id)
        {
            return RedirectToAction("../ProspectivoContato/Create", new {id = id});
        }

        public ActionResult Report()
        {
            List<Prospectivo> prospectivolst = db.Prospectivo.ToList().OrderBy(o => o.ProspectivoNome).ToList();

            for (int i = 0; i < prospectivolst.Count(); i++)
            {
                prospectivolst[i].Contatos = new List<ProspectivoContato>();

                int id = (int)prospectivolst[i].ProspectivoCod;

                var prospectivoContato = db.ProspectivoContato.Include(p => p.Prospectivo).Where(c => c.ProspectivoCod == id)
                                                                                                     .OrderByDescending(o => o.ProspectivoContatoData);

                prospectivolst[i].Contatos = prospectivoContato.ToList();
            }

            return View(prospectivolst);
        }
    }
}
