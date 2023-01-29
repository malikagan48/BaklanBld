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
    public class MuhtarlikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Muhtarlik
        public ActionResult Index()
        {
            var h = db.Muhtarlik.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Muhtarlik.Where(x => x.MuhtarlikId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Muhtarlik h)
        {
            if (ModelState.IsValid)
            {
                var Muhtarlik = db.Muhtarlik.Where(x => x.MuhtarlikId == id).SingleOrDefault();
                Muhtarlik.MuhtarlikAciklama = h.MuhtarlikAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}