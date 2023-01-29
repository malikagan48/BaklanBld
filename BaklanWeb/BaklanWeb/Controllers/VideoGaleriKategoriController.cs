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
    public class VideoGaleriKategoriController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: VideoGaleriKategori
        public ActionResult Index()
        {
            return View(db.VideoGaleriKategoris.ToList());
        }

        // GET: VideoGaleriKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGaleriKategori VideoGaleriKategori = db.VideoGaleriKategoris.Find(id);
            if (VideoGaleriKategori == null)
            {
                return HttpNotFound();
            }
            return View(VideoGaleriKategori);
        }

        // GET: VideoGaleriKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGaleriKategori/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGaleriKategoriId,VideoGaleriKategoriAd,VideoGaleriKategoriAciklama")] VideoGaleriKategori VideoGaleriKategori)
        {
            if (ModelState.IsValid)
            {
                db.VideoGaleriKategoris.Add(VideoGaleriKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(VideoGaleriKategori);
        }

        // GET: VideoGaleriKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGaleriKategori VideoGaleriKategori = db.VideoGaleriKategoris.Find(id);
            if (VideoGaleriKategori == null)
            {
                return HttpNotFound();
            }
            return View(VideoGaleriKategori);
        }

        // POST: VideoGaleriKategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGaleriKategoriId,VideoGaleriKategoriAd,VideoGaleriKategoriAciklama")] VideoGaleriKategori VideoGaleriKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VideoGaleriKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(VideoGaleriKategori);
        }

        // GET: VideoGaleriKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGaleriKategori VideoGaleriKategori = db.VideoGaleriKategoris.Find(id);
            if (VideoGaleriKategori == null)
            {
                return HttpNotFound();
            }
            return View(VideoGaleriKategori);
        }

        // POST: VideoGaleriKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGaleriKategori VideoGaleriKategori = db.VideoGaleriKategoris.Find(id);
            db.VideoGaleriKategoris.Remove(VideoGaleriKategori);
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
