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
    public class DuyurularController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: Duyurular
        public ActionResult Index()
        {
            return View(db.Duyurular.ToList());
        }

        // GET: Duyurular/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // GET: Duyurular/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DuyurularId,DuyurularBaslik,DuyurularAciklama,DuyurularResimURL")] Duyurular duyurular, HttpPostedFileBase DuyurularResimURL)
        {
            if (ModelState.IsValid)
            {
                if (DuyurularResimURL != null)
                {
                    WebImage img = new WebImage(DuyurularResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(DuyurularResimURL.FileName);

                    string duyurularimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Duyurular/" + duyurularimgname);

                    duyurular.DuyurularResimURL = "/Uploads/Duyurular/" + duyurularimgname;
                }
                db.Duyurular.Add(duyurular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duyurular);
        }

        // GET: Duyurular/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // POST: Duyurular/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateInput(false)]

        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DuyurularId,DuyurularBaslik,DuyurularAciklama,DuyurularResimURL")] Duyurular duyurular, HttpPostedFileBase DuyurularResimURL,int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Duyurular.Where(x => x.DuyurularId == id).SingleOrDefault();
                if (DuyurularResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.DuyurularResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.DuyurularResimURL));
                    }
                    WebImage img = new WebImage(DuyurularResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(DuyurularResimURL.FileName);

                    string duyurularimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Duyurular/" + duyurularimgname);

                    s.DuyurularResimURL = "/Uploads/Duyurular/" + duyurularimgname;
                }
                s.DuyurularBaslik = duyurular.DuyurularBaslik;
                s.DuyurularAciklama = duyurular.DuyurularAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duyurular);
        }

        // GET: Duyurular/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // POST: Duyurular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duyurular duyurular = db.Duyurular.Find(id);
            if (System.IO.File.Exists(Server.MapPath(duyurular.DuyurularResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(duyurular.DuyurularResimURL));
            }
            db.Duyurular.Remove(duyurular);
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
