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
    public class FestivallerController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Festivaller
        public ActionResult Index()
        {
            var h = db.Festivaller.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Festivaller.Where(x => x.FestivallerId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Festivaller h)
        {
            if (ModelState.IsValid)
            {
                var Festivaller = db.Festivaller.Where(x => x.FestivallerId == id).SingleOrDefault();
                Festivaller.FestivallerAciklama = h.FestivallerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}