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
    public class FotoGaleriController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: FotoGaleri
        public ActionResult Index()
        {
            var FotoGaleri = db.FotoGaleri.Include(t => t.FotoGaleriKategori);
            return View(FotoGaleri.ToList());
        }



        // GET: FotoGaleri/Create
        public ActionResult Create()
        {
            ViewBag.FotoGaleriKategoriId = new SelectList(db.FotoGaleriKategoris, "FotoGaleriKategoriId", "FotoGaleriKategoriAd");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FotoGaleri FotoGaleri, HttpPostedFileBase FotoGaleriResimURL)
        {
            if (ModelState.IsValid)
            {
                if (FotoGaleriResimURL != null)
                {
                    WebImage img = new WebImage(FotoGaleriResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(FotoGaleriResimURL.FileName);
                    string FotoGaleriname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/FotoGaleri/" + FotoGaleriname);
                    FotoGaleri.FotoGaleriResimURL = "/Uploads/FotoGaleri/" + FotoGaleriname;
                }
                db.FotoGaleri.Add(FotoGaleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(FotoGaleri);
        }

        // GET: FotoGaleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Proje Bulunamadı";
            }
            var b = db.FotoGaleri.Where(x => x.FotoGaleriId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.FotoGaleriKategoriId = new SelectList(db.FotoGaleriKategoris, "FotoGaleriKategoriId", "FotoGaleriKategoriAd", b.FotoGaleriKategoriId);
            return View(b);
        }

        // POST: FotoGaleri/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, FotoGaleri FotoGaleri, HttpPostedFileBase FotoGaleriResimURL)

        {
            if (ModelState.IsValid)
            {
                var h = db.FotoGaleri.Where(x => x.FotoGaleriId == id).SingleOrDefault();
                if (FotoGaleriResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.FotoGaleriResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.FotoGaleriResimURL));
                    }
                    WebImage img = new WebImage(FotoGaleriResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(FotoGaleriResimURL.FileName);

                    string FotoGaleriname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/FotoGaleri/" + FotoGaleriname);

                    h.FotoGaleriResimURL = "/Uploads/FotoGaleri/" + FotoGaleriname;
                }
                h.FotoGaleriBaslik = FotoGaleri.FotoGaleriBaslik;
                h.FotoGaleriKategoriId = FotoGaleri.FotoGaleriKategoriId;
                h.FotoGaleriAciklama = FotoGaleri.FotoGaleriAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(FotoGaleri);
        }

        [ValidateAntiForgeryToken]

        // GET: FotoGaleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.FotoGaleri.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.FotoGaleri.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
