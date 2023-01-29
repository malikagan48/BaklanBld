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
    public class OnemliTelefonlarController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  OnemliTelefonlar
        public ActionResult Index()
        {
            var h = db.OnemliTelefonlar.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.OnemliTelefonlar.Where(x => x.OnemliTelefonlarId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, OnemliTelefonlar h)
        {
            if (ModelState.IsValid)
            {
                var OnemliTelefonlar = db.OnemliTelefonlar.Where(x => x.OnemliTelefonlarId == id).SingleOrDefault();
                OnemliTelefonlar.OnemliTelefonlarAciklama = h.OnemliTelefonlarAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}