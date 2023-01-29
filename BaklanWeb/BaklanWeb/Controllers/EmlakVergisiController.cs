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
    public class EmlakVergisiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET: EmlakVergisi
        public ActionResult Index()
        {
            var h = db.EmlakVergisi.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.EmlakVergisi.Where(x => x.EmlakVergisiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,EmlakVergisi h)
        {
            if (ModelState.IsValid)
            {
                var EmlakVergisi = db.EmlakVergisi.Where(x => x.EmlakVergisiId == id).SingleOrDefault();
               EmlakVergisi.EmlakVergisiAciklama = h.EmlakVergisiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}