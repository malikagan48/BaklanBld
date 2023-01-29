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
    public class TamamlananProjelerKategoriController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: TamamlananProjelerKategori
        public ActionResult Index()
        {
            return View(db.TamamlananProjelerKategoris.ToList());
        }

        // GET: TamamlananProjelerKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TamamlananProjelerKategori TamamlananProjelerKategori = db.TamamlananProjelerKategoris.Find(id);
            if (TamamlananProjelerKategori == null)
            {
                return HttpNotFound();
            }
            return View(TamamlananProjelerKategori);
        }

        // GET: TamamlananProjelerKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TamamlananProjelerKategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TamamlananProjelerKategoriId,TamamlananProjelerKategoriAd,TamamlananProjelerKategoriAciklama")] TamamlananProjelerKategori TamamlananProjelerKategori)
        {
            if (ModelState.IsValid)
            {
                db.TamamlananProjelerKategoris.Add(TamamlananProjelerKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TamamlananProjelerKategori);
        }

        // GET: TamamlananProjelerKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TamamlananProjelerKategori TamamlananProjelerKategori = db.TamamlananProjelerKategoris.Find(id);
            if (TamamlananProjelerKategori == null)
            {
                return HttpNotFound();
            }
            return View(TamamlananProjelerKategori);
        }

        // POST: TamamlananProjelerKategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TamamlananProjelerKategoriId,TamamlananProjelerKategoriAd,TamamlananProjelerKategoriAciklama")] TamamlananProjelerKategori TamamlananProjelerKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TamamlananProjelerKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TamamlananProjelerKategori);
        }

        // GET: TamamlananProjelerKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TamamlananProjelerKategori TamamlananProjelerKategori = db.TamamlananProjelerKategoris.Find(id);
            if (TamamlananProjelerKategori == null)
            {
                return HttpNotFound();
            }
            return View(TamamlananProjelerKategori);
        }

        // POST: TamamlananProjelerKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TamamlananProjelerKategori TamamlananProjelerKategori = db.TamamlananProjelerKategoris.Find(id);
            db.TamamlananProjelerKategoris.Remove(TamamlananProjelerKategori);
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
