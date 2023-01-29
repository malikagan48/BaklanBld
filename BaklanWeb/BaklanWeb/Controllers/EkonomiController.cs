using BaklanWeb.Models.DataContext;
using BaklanWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BaklanWeb.Controllers
{
    public class EkonomiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Ekonomi
        public ActionResult Index()
        {
            var h = db.Ekonomi.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Ekonomi.Where(x => x.EkonomiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Ekonomi h)
        {
            if (ModelState.IsValid)
            {
                var Ekonomi = db.Ekonomi.Where(x => x.EkonomiId == id).SingleOrDefault();
                Ekonomi.EkonomiAciklama = h.EkonomiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}