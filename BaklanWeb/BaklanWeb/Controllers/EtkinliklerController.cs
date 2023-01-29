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
    public class EtkinliklerController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Etkinlikler
        public ActionResult Index()
        {
            var h = db.Etkinlikler.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Etkinlikler.Where(x => x.EtkinliklerId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Etkinlikler h)
        {
            if (ModelState.IsValid)
            {
                var Etkinlikler = db.Etkinlikler.Where(x => x.EtkinliklerId == id).SingleOrDefault();
                Etkinlikler.EtkinliklerAciklama = h.EtkinliklerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}