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
    public class EskiBaskanlarController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  EskiBaskanlar
        public ActionResult Index()
        {
            var h = db.EskiBaskanlar.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.EskiBaskanlar.Where(x => x.EskiBaskanlarId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, EskiBaskanlar h)
        {
            if (ModelState.IsValid)
            {
                var EskiBaskanlar = db.EskiBaskanlar.Where(x => x.EskiBaskanlarId == id).SingleOrDefault();
                EskiBaskanlar.EskiBaskanlarAciklama = h.EskiBaskanlarAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}