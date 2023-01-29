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
    public class MeclisUyeleriController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  MeclisUyeleri
        public ActionResult Index()
        {
            var h = db.MeclisUyeleri.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.MeclisUyeleri.Where(x => x.MeclisUyeleriId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, MeclisUyeleri h)
        {
            if (ModelState.IsValid)
            {
                var MeclisUyeleri = db.MeclisUyeleri.Where(x => x.MeclisUyeleriId == id).SingleOrDefault();
                MeclisUyeleri.MeclisUyeleriAciklama = h.MeclisUyeleriAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}