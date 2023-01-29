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
    public class TurizmController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: Turizm
        public ActionResult Index()
        {
            var turizm = db.Turizm.Include(t => t.TurizmKategori);
            return View(turizm.ToList());
        }

  

        // GET: Turizm/Create
        public ActionResult Create()
        {
            ViewBag.TurizmKategoriId = new SelectList(db.TurizmKategori, "TurizmKategoriId", "TurizmKategoriAd");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Turizm Turizm, HttpPostedFileBase TurizmResimURL)
        {
            if (ModelState.IsValid)
            {
                if (TurizmResimURL != null)
                {
                    WebImage img = new WebImage(TurizmResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(TurizmResimURL.FileName);
                    string Turizmname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Turizm/" + Turizmname);
                    Turizm.TurizmResimURL = "/Uploads/Turizm/" + Turizmname;
                }
                db.Turizm.Add(Turizm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Turizm);
        }

        // GET: Turizm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Proje Bulunamadı";
            }
            var b = db.Turizm.Where(x=>x.TurizmId==id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.TurizmKategoriId = new SelectList(db.TurizmKategori, "TurizmKategoriId", "TurizmKategoriAd",b.TurizmKategoriId);
            return View(b);
        }

        // POST: Turizm/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Turizm Turizm, HttpPostedFileBase TurizmResimURL)

        {
            if (ModelState.IsValid)
            {
                var h = db.Turizm.Where(x => x.TurizmId == id).SingleOrDefault();
                if (TurizmResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.TurizmResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.TurizmResimURL));
                    }
                    WebImage img = new WebImage(TurizmResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(TurizmResimURL.FileName);

                    string Turizmname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Turizm/" + Turizmname);

                    h.TurizmResimURL = "/Uploads/Turizm/" + Turizmname;
                }
                h.TurizmBaslik = Turizm.TurizmBaslik;
                h.TurizmKategoriId = Turizm.TurizmKategoriId;
                h.TurizmAciklama = Turizm.TurizmAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(Turizm);
        }

        [ValidateAntiForgeryToken]

        // GET: Turizm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.Turizm.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Turizm.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
