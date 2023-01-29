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
    public class EvlenmeIsleriController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  EvlenmeIsleri
        public ActionResult Index()
        {
            var h = db.EvlenmeIsleri.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.EvlenmeIsleri.Where(x => x.EvlenmeIsleriId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, EvlenmeIsleri h)
        {
            if (ModelState.IsValid)
            {
                var EvlenmeIsleri = db.EvlenmeIsleri.Where(x => x.EvlenmeIsleriId == id).SingleOrDefault();
                EvlenmeIsleri.EvlenmeIsleriAciklama = h.EvlenmeIsleriAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}