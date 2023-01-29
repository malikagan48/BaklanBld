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
    public class TamamlananProjelerController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: TamamlananProjeler
        public ActionResult Index()
        {
            var TamamlananProjeler = db.TamamlananProjeler.Include(t => t.TamamlananProjelerKategori);
            return View(TamamlananProjeler.ToList());
        }



        // GET: TamamlananProjeler/Create
        public ActionResult Create()
        {
            ViewBag.TamamlananProjelerKategoriId = new SelectList(db.TamamlananProjelerKategoris, "TamamlananProjelerKategoriId", "TamamlananProjelerKategoriAd");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TamamlananProjeler TamamlananProjeler, HttpPostedFileBase TamamlananProjelerResimURL)
        {
            if (ModelState.IsValid)
            {
                if (TamamlananProjelerResimURL != null)
                {
                    WebImage img = new WebImage(TamamlananProjelerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(TamamlananProjelerResimURL.FileName);
                    string TamamlananProjelername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/TamamlananProjeler/" + TamamlananProjelername);
                    TamamlananProjeler.TamamlananProjelerResimURL = "/Uploads/TamamlananProjeler/" + TamamlananProjelername;
                }
                db.TamamlananProjeler.Add(TamamlananProjeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TamamlananProjeler);
        }

        // GET: TamamlananProjeler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Proje Bulunamadı";
            }
            var b = db.TamamlananProjeler.Where(x => x.TamamlananProjelerId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.TamamlananProjelerKategoriId = new SelectList(db.TamamlananProjelerKategoris, "TamamlananProjelerKategoriId", "TamamlananProjelerKategoriAd", b.TamamlananProjelerKategoriId);
            return View(b);
        }

        // POST: TamamlananProjeler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, TamamlananProjeler TamamlananProjeler, HttpPostedFileBase TamamlananProjelerResimURL)

        {
            if (ModelState.IsValid)
            {
                var h = db.TamamlananProjeler.Where(x => x.TamamlananProjelerId == id).SingleOrDefault();
                if (TamamlananProjelerResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.TamamlananProjelerResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.TamamlananProjelerResimURL));
                    }
                    WebImage img = new WebImage(TamamlananProjelerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(TamamlananProjelerResimURL.FileName);

                    string TamamlananProjelername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/TamamlananProjeler/" + TamamlananProjelername);

                    h.TamamlananProjelerResimURL = "/Uploads/TamamlananProjeler/" + TamamlananProjelername;
                }
                h.TamamlananProjelerBaslik = TamamlananProjeler.TamamlananProjelerBaslik;
                h.TamamlananProjelerKategoriId = TamamlananProjeler.TamamlananProjelerKategoriId;
                h.TamamlananProjelerAciklama = TamamlananProjeler.TamamlananProjelerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(TamamlananProjeler);
        }

        [ValidateAntiForgeryToken]

        // GET: TamamlananProjeler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.TamamlananProjeler.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.TamamlananProjeler.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
