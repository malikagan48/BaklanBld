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
    public class EgitimController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Egitim
        public ActionResult Index()
        {
            var h = db.Egitim.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Egitim.Where(x => x.EgitimId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Egitim h)
        {
            if (ModelState.IsValid)
            {
                var Egitim = db.Egitim.Where(x => x.EgitimId == id).SingleOrDefault();
                Egitim.EgitimAciklama = h.EgitimAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}