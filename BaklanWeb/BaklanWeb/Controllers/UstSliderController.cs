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
    public class SliderController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: Slider
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider Slider = db.Slider.Find(id);
            if (Slider == null)
            {
                return HttpNotFound();
            }
            return View(Slider);
        }

        // GET: Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,SliderBaslik,SliderAciklama,SliderResimURL")] Slider Slider, HttpPostedFileBase SliderResimURL)
        {
            if (ModelState.IsValid)
            {
                if (SliderResimURL != null)
                {
                    WebImage img = new WebImage(SliderResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(SliderResimURL.FileName);

                    string Sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + Sliderimgname);

                    Slider.SliderResimURL = "/Uploads/Slider/" + Sliderimgname;
                }
                db.Slider.Add(Slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Slider);
        }

        // GET: Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider Slider = db.Slider.Find(id);
            if (Slider == null)
            {
                return HttpNotFound();
            }
            return View(Slider);
        }

        // POST: Slider/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,SliderBaslik,SliderAciklama,SliderResimURL")] Slider Slider, HttpPostedFileBase SliderResimURL, int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();
                if (SliderResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.SliderResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.SliderResimURL));
                    }
                    WebImage img = new WebImage(SliderResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(SliderResimURL.FileName);

                    string Sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + Sliderimgname);

                    s.SliderResimURL = "/Uploads/Slider/" + Sliderimgname;
                }
                s.SliderBaslik = Slider.SliderBaslik;
                s.SliderAciklama = Slider.SliderAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Slider);
        }

        // GET: Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider Slider = db.Slider.Find(id);
            if (Slider == null)
            {
                return HttpNotFound();
            }
            return View(Slider);
        }

        // POST: Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider Slider = db.Slider.Find(id);
            if (System.IO.File.Exists(Server.MapPath(Slider.SliderResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(Slider.SliderResimURL));
            }
            db.Slider.Remove(Slider);
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

