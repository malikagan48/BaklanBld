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
    public class TarihiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Tarihi
        public ActionResult Index()
        {
            var h = db.Tarihi.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Tarihi.Where(x => x.TarihiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Tarihi h)
        {
            if (ModelState.IsValid)
            {
                var Tarihi = db.Tarihi.Where(x => x.TarihiId == id).SingleOrDefault();
                Tarihi.TarihiAciklama = h.TarihiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}