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
    public class CografiYapisiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  CografiYapisi
        public ActionResult Index()
        {
            var h = db.CografiYapisi.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.CografiYapisi.Where(x => x.CografiYapisiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, CografiYapisi h)
        {
            if (ModelState.IsValid)
            {
                var CografiYapisi = db.CografiYapisi.Where(x => x.CografiYapisiId == id).SingleOrDefault();
                CografiYapisi.CografiYapisiAciklama = h.CografiYapisiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}