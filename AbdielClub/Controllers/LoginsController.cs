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

namespace AbdielClub.Controllers
{
    public class LoginsController : Controller
    {
        private AbdielClubDbContext db = new AbdielClubDbContext();

        // GET: Logins
        public async Task<ActionResult> Index()
        {
            return View(await db.Login.ToListAsync());
        }

        public  ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            bool user = db.Login.Any(x => x.User == login.User && x.Password == login.Password);
            if (user)
            {
                ViewBag.Login = 1;
          
                return RedirectToAction("Home");
            }

            ViewBag.Login = 0;
            return View(login);
        }

        public ActionResult Home()
        {
            return View();
        }

        // GET: Logins/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = await db.Login.FindAsync(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "User,Password,Nombre")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Login.Add(login);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = await db.Login.FindAsync(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User,Password,Nombre")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = await db.Login.FindAsync(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Login login = await db.Login.FindAsync(id);
            db.Login.Remove(login);
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
