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
    public class InsaatRuhsatiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  InsaatRuhsati
        public ActionResult Index()
        {
            var h = db.InsaatRuhsati.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.InsaatRuhsati.Where(x => x.InsaatRuhsatiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, InsaatRuhsati h)
        {
            if (ModelState.IsValid)
            {
                var InsaatRuhsati = db.InsaatRuhsati.Where(x => x.InsaatRuhsatiId == id).SingleOrDefault();
                InsaatRuhsati.InsaatRuhsatiAciklama = h.InsaatRuhsatiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}