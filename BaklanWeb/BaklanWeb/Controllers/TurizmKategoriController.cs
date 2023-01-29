using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaklanWeb.Models.DataContext;
using BaklanWeb.Models.Model;

namespace BaklanWeb.Controllers
{
    public class TurizmKategoriController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: TurizmKategori
        public ActionResult Index()
        {
            return View(db.TurizmKategori.ToList());
        }

        // GET: TurizmKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurizmKategori turizmKategori = db.TurizmKategori.Find(id);
            if (turizmKategori == null)
            {
                return HttpNotFound();
            }
            return View(turizmKategori);
        }

        // GET: TurizmKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurizmKategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TurizmKategoriId,TurizmKategoriAd,TurizmKategoriAciklama")] TurizmKategori turizmKategori)
        {
            if (ModelState.IsValid)
            {
                db.TurizmKategori.Add(turizmKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turizmKategori);
        }

        // GET: TurizmKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurizmKategori turizmKategori = db.TurizmKategori.Find(id);
            if (turizmKategori == null)
            {
                return HttpNotFound();
            }
            return View(turizmKategori);
        }

        // POST: TurizmKategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TurizmKategoriId,TurizmKategoriAd,TurizmKategoriAciklama")] TurizmKategori turizmKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turizmKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turizmKategori);
        }

        // GET: TurizmKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurizmKategori turizmKategori = db.TurizmKategori.Find(id);
            if (turizmKategori == null)
            {
                return HttpNotFound();
            }
            return View(turizmKategori);
        }

        // POST: TurizmKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TurizmKategori turizmKategori = db.TurizmKategori.Find(id);
            db.TurizmKategori.Remove(turizmKategori);
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
