using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbdielClub.Context;
using AbdielClub.Models;
using System.Web.Helpers;

namespace AbdielClub.Controllers
{
    public class SociosController : Controller
    {
        private AbdielClubDbContext db = new AbdielClubDbContext();

        // GET: Socios
        public async Task<ActionResult> Index()
        {
            return View(await db.Socios.ToListAsync());
        }

        // GET: Socios/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = await db.Socios.FindAsync(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            ViewData["fechaActual"] = DateTime.Now;
            Socio socio = new Socio { Tipo_Membresia = Enums.Membresias.Bronce, Afiliados = Enums.Afiliados.Hijos , Sexo = Enums.Sexo.Masculino };
            return View(socio);
        }

        // POST: Socios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Socio socio)
        {
            try
            {
                HttpPostedFileBase fileBase = Request.Files[0];
                WebImage image = new WebImage(fileBase.InputStream);
                socio.Foto = image.GetBytes();
            }
            catch
            {
                socio.Foto = null;
            }

            socio.Estado = Enums.Estados.Activo;
         

            if (ModelState.IsValid)
            {
                db.Socios.Add(socio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(socio);
        }

        // GET: Socios/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = await db.Socios.FindAsync(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Socio socio)
        {

            try
            {
                HttpPostedFileBase fileBase = Request.Files[0];
                WebImage image = new WebImage(fileBase.InputStream);
                socio.Foto = image.GetBytes();
            }
            catch
            {
            }

            if (ModelState.IsValid)
            {
                db.Entry(socio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: Socios/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = await db.Socios.FindAsync(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Socio socio = await db.Socios.FindAsync(id);
            db.Socios.Remove(socio);
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
