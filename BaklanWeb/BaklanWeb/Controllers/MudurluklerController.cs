using System;
using System.Collections.Generic;
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
    public class MudurluklerController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: Mudurlukler
        public ActionResult Index()
        {
            return View(db.Mudurlukler.ToList());
        }

     
        // GET: Mudurlukler/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Mudurlukler Mudurlukler, HttpPostedFileBase MudurluklerResimURL)
        {
            if (ModelState.IsValid)
            {
                if (MudurluklerResimURL != null)
                {
                    WebImage img = new WebImage(MudurluklerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(MudurluklerResimURL.FileName);
                    string Mudurluklername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Mudurlukler/" + Mudurluklername);
                    Mudurlukler.MudurluklerResimURL = "/Uploads/Mudurlukler/" + Mudurluklername;
                }
                db.Mudurlukler.Add(Mudurlukler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Mudurlukler);
        }

        // GET: Mudurlukler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Proje Bulunamadı";
            }
            var Mudurlukler = db.Mudurlukler.Find(id);
            if (Mudurlukler == null)
            {
                return HttpNotFound();
            }
            return View(Mudurlukler);
        }

        // POST: Mudurlukler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Mudurlukler Mudurlukler, HttpPostedFileBase MudurluklerResimURL)
        {
            if (ModelState.IsValid)
            {
                var h = db.Mudurlukler.Where(x => x.MudurluklerId == id).SingleOrDefault();
                if (MudurluklerResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.MudurluklerResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.MudurluklerResimURL));
                    }
                    WebImage img = new WebImage(MudurluklerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(MudurluklerResimURL.FileName);

                    string Mudurluklername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Mudurlukler/" + Mudurluklername);

                    h.MudurluklerResimURL = "/Uploads/Mudurlukler/" + Mudurluklername;
                }
                h.MudurluklerBaslik = Mudurlukler.MudurluklerBaslik;
                h.MudurluklerAciklama = Mudurlukler.MudurluklerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: Mudurlukler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.Mudurlukler.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Mudurlukler.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
