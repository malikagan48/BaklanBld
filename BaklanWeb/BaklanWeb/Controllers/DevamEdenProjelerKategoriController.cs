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
    public class DevamEdenProjelerKategoriController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: DevamEdenProjelerKategori
        public ActionResult Index()
        {
            return View(db.DevamEdenProjelerKategoris.ToList());
        }

        // GET: DevamEdenProjelerKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevamEdenProjelerKategori DevamEdenProjelerKategori = db.DevamEdenProjelerKategoris.Find(id);
            if (DevamEdenProjelerKategori == null)
            {
                return HttpNotFound();
            }
            return View(DevamEdenProjelerKategori);
        }

        // GET: DevamEdenProjelerKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DevamEdenProjelerKategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DevamEdenProjelerKategoriId,DevamEdenProjelerKategoriAd,DevamEdenProjelerKategoriAciklama")] DevamEdenProjelerKategori DevamEdenProjelerKategori)
        {
            if (ModelState.IsValid)
            {
                db.DevamEdenProjelerKategoris.Add(DevamEdenProjelerKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(DevamEdenProjelerKategori);
        }

        // GET: DevamEdenProjelerKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevamEdenProjelerKategori DevamEdenProjelerKategori = db.DevamEdenProjelerKategoris.Find(id);
            if (DevamEdenProjelerKategori == null)
            {
                return HttpNotFound();
            }
            return View(DevamEdenProjelerKategori);
        }

        // POST: DevamEdenProjelerKategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DevamEdenProjelerKategoriId,DevamEdenProjelerKategoriAd,DevamEdenProjelerKategoriAciklama")] DevamEdenProjelerKategori DevamEdenProjelerKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(DevamEdenProjelerKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(DevamEdenProjelerKategori);
        }

        // GET: DevamEdenProjelerKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevamEdenProjelerKategori DevamEdenProjelerKategori = db.DevamEdenProjelerKategoris.Find(id);
            if (DevamEdenProjelerKategori == null)
            {
                return HttpNotFound();
            }
            return View(DevamEdenProjelerKategori);
        }

        // POST: DevamEdenProjelerKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevamEdenProjelerKategori DevamEdenProjelerKategori = db.DevamEdenProjelerKategoris.Find(id);
            db.DevamEdenProjelerKategoris.Remove(DevamEdenProjelerKategori);
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
