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
    public class DevamEdenProjelerController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: DevamEdenProjeler
        public ActionResult Index()
        {
            var DevamEdenProjeler = db.DevamEdenProjeler.Include(d => d.DevamEdenProjelerKategori);
            return View(DevamEdenProjeler.ToList());
        }

   

        // GET: DevamEdenProjeler/Create
        public ActionResult Create()
        {
            ViewBag.DevamEdenProjelerKategoriId = new SelectList(db.DevamEdenProjelerKategoris, "DevamEdenProjelerKategoriId", "DevamEdenProjelerKategoriAd");
            return View();
        }

        // POST: DevamEdenProjeler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DevamEdenProjeler DevamEdenProjeler,HttpPostedFileBase DevamedenProjelerResimURL)
        {
            if (ModelState.IsValid)
            {
                if (DevamedenProjelerResimURL != null)
                {
                    WebImage img = new WebImage(DevamedenProjelerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(DevamedenProjelerResimURL.FileName);
                    string DevamEdenProjelername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/DevamEdenProjeler/" + DevamEdenProjelername);
                DevamEdenProjeler.DevamEdenProjelerResimURL = "/Uploads/DevamEdenProjeler/" + DevamEdenProjelername;
                }
                db.DevamEdenProjeler.Add(DevamEdenProjeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(DevamEdenProjeler);
        }

        // GET: DevamEdenProjeler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Proje Bulunamadı";
            }
            var b = db.DevamEdenProjeler.Where(x => x.DevamEdenProjelerId == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.DevamEdenProjelerKategoriId = new SelectList(db.DevamEdenProjelerKategoris, "DevamEdenProjelerKategoriId", "DevamEdenProjelerKategoriAd", b.DevamEdenProjelerKategoriId);
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, DevamEdenProjeler DevamEdenProjeler, HttpPostedFileBase DevamEdenProjelerResimURL)

        {
            if (ModelState.IsValid)
            {
                var h = db.DevamEdenProjeler.Where(x => x.DevamEdenProjelerId == id).SingleOrDefault();
                if (DevamEdenProjelerResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.DevamEdenProjelerResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.DevamEdenProjelerResimURL));
                    }
                    WebImage img = new WebImage(DevamEdenProjelerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(DevamEdenProjelerResimURL.FileName);

                    string DevamEdenProjelername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/DevamEdenProjeler/" + DevamEdenProjelername);

                    h.DevamEdenProjelerResimURL = "/Uploads/DevamEdenProjeler/" + DevamEdenProjelername;
                }
                h.DevamEdenProjelerBaslik = DevamEdenProjeler.DevamEdenProjelerBaslik;
                h.DevamEdenProjelerKategoriId = DevamEdenProjeler.DevamEdenProjelerKategoriId;
                h.DevamEdenProjelerAciklama = DevamEdenProjeler.DevamEdenProjelerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(DevamEdenProjeler);
        }

        [ValidateAntiForgeryToken]

        // GET: DevamEdenProjeler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.DevamEdenProjeler.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.DevamEdenProjeler.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
