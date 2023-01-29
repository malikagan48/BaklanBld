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
    public class HaberlerSliderController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
       

        // GET: HaberlerSlider
        public ActionResult Index()
        {
            return View(db.HaberlerSlider.ToList());
        }

        // GET: HaberlerSlider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HaberlerSlider haberlerSlider = db.HaberlerSlider.Find(id);
            if (haberlerSlider == null)
            {
                return HttpNotFound();
            }
            return View(haberlerSlider);
        }

        // GET: HaberlerSlider/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HaberlerSliderId,HaberlerBaslik,HaberlerAciklama,HaberlerResimURL")] HaberlerSlider HaberlerSlider, HttpPostedFileBase HaberlerResimURL)
        {
            if (ModelState.IsValid)
            {
                if (HaberlerResimURL != null)
                {
                    WebImage img = new WebImage(HaberlerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(HaberlerResimURL.FileName);

                    string HaberlerSliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/HaberlerSlider/" + HaberlerSliderimgname);

                    HaberlerSlider.HaberlerResimURL = "/Uploads/HaberlerSlider/" + HaberlerSliderimgname;
                }
                db.HaberlerSlider.Add(HaberlerSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(HaberlerSlider);
        }

        // GET: HaberlerSlider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HaberlerSlider HaberlerSlider = db.HaberlerSlider.Find(id);
            if (HaberlerSlider == null)
            {
                return HttpNotFound();
            }
            return View(HaberlerSlider);
        }

        // POST: HaberlerSlider/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HaberlerSliderId,HaberlerBaslik,HaberlerAciklama,HaberlerResimURL")] HaberlerSlider HaberlerSlider, HttpPostedFileBase HaberlerResimURL, int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.HaberlerSlider.Where(x => x.HaberlerSliderId == id).SingleOrDefault();
                if (HaberlerResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.HaberlerResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.HaberlerResimURL));
                    }
                    WebImage img = new WebImage(HaberlerResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(HaberlerResimURL.FileName);

                    string HaberlerSliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/HaberlerSlider/" + HaberlerSliderimgname);

                    s.HaberlerResimURL = "/Uploads/HaberlerSlider/" + HaberlerSliderimgname;
                }
                s.HaberlerBaslik = HaberlerSlider.HaberlerBaslik;
                s.HaberlerAciklama = HaberlerSlider.HaberlerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(HaberlerSlider);
        }

        // GET: HaberlerSlider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HaberlerSlider HaberlerSlider = db.HaberlerSlider.Find(id);
            if (HaberlerSlider == null)
            {
                return HttpNotFound();
            }
            return View(HaberlerSlider);
        }

        // POST: HaberlerSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HaberlerSlider HaberlerSlider = db.HaberlerSlider.Find(id);
            if (System.IO.File.Exists(Server.MapPath(HaberlerSlider.HaberlerResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(HaberlerSlider.HaberlerResimURL));
            }
            db.HaberlerSlider.Remove(HaberlerSlider);
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

