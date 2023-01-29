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
    public class TatilCalismaRuhsatiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  TatilCalismaRuhsati
        public ActionResult Index()
        {
            var h = db.TatilCalismaRuhsati.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.TatilCalismaRuhsati.Where(x => x.TatilCalismaRuhsatiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, TatilCalismaRuhsati h)
        {
            if (ModelState.IsValid)
            {
                var TatilCalismaRuhsati = db.TatilCalismaRuhsati.Where(x => x.TatilCalismaRuhsatiId == id).SingleOrDefault();
                TatilCalismaRuhsati.TatilCalismaRuhsatiAciklama = h.TatilCalismaRuhsatiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}