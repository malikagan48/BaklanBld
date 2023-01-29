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
    public class EncümenUyelerController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  EncümenUyeler
        public ActionResult Index()
        {
            var h = db.EncümenUyeler.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.EncümenUyeler.Where(x => x.EncümenUyelerId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, EncümenUyeler h)
        {
            if (ModelState.IsValid)
            {
                var EncümenUyeler = db.EncümenUyeler.Where(x => x.EncümenUyelerId == id).SingleOrDefault();
                EncümenUyeler.EncümenUyelerAciklama = h.EncümenUyelerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}