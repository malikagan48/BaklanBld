using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BaklanWeb.Models.DataContext;
using BaklanWeb.Models.Model;

namespace BaklanWeb.Controllers
{
    public class VideoGaleriController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: VideoGaleri
        public ActionResult Index()
        {
            var VideoGaleri = db.VideoGaleri.Include(t => t.VideoGaleriKategori);
            return View(VideoGaleri.ToList());
        }



        // GET: VideoGaleri/Create
        public ActionResult Create()
        {
            ViewBag.VideoGaleriKategoriId = new SelectList(db.VideoGaleriKategoris, "VideoGaleriKategoriId", "VideoGaleriKategoriAd");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoGaleri VideoGaleri, HttpPostedFileBase VideoGaleriResimURL)
        {
            if (ModelState.IsValid)
            {
                if (VideoGaleriResimURL != null)
                {
                    WebImage img = new WebImage(VideoGaleriResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(VideoGaleriResimURL.FileName);
                    string VideoGaleriname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/VideoGaleri/" + VideoGaleriname);
                    VideoGaleri.VideoGaleriResimURL = "/Uploads/VideoGaleri/" + VideoGaleriname;
                }
                db.VideoGaleri.Add(VideoGaleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(VideoGaleri);
        }

        // GET: VideoGaleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Proje Bulunamadı";
            }
            var b = db.VideoGaleri.Where(x => x.VideoGaleriId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoGaleriKategoriId = new SelectList(db.VideoGaleriKategoris, "VideoGaleriKategoriId", "VideoGaleriKategoriAd", b.VideoGaleriKategoriId);
            return View(b);
        }

        // POST: VideoGaleri/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, VideoGaleri VideoGaleri, HttpPostedFileBase VideoGaleriResimURL)

        {
            if (ModelState.IsValid)
            {
                var h = db.VideoGaleri.Where(x => x.VideoGaleriId == id).SingleOrDefault();
                if (VideoGaleriResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.VideoGaleriResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.VideoGaleriResimURL));
                    }
                    WebImage img = new WebImage(VideoGaleriResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(VideoGaleriResimURL.FileName);

                    string VideoGaleriname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/VideoGaleri/" + VideoGaleriname);

                    h.VideoGaleriResimURL = "/Uploads/VideoGaleri/" + VideoGaleriname;
                }
                h.VideoGaleriBaslik = VideoGaleri.VideoGaleriBaslik;
                h.VideoGaleriKategoriId = VideoGaleri.VideoGaleriKategoriId;
                h.VideoGaleriAciklama = VideoGaleri.VideoGaleriAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(VideoGaleri);
        }

        [ValidateAntiForgeryToken]

        // GET: VideoGaleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.VideoGaleri.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.VideoGaleri.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
