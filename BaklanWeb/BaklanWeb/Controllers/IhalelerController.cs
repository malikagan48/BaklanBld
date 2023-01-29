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
    public class IhalelerController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Ihaleler
        public ActionResult Index()
        {
            var h = db.Ihaleler.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Ihaleler.Where(x => x.IhalelerId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Ihaleler h)
        {
            if (ModelState.IsValid)
            {
                var Ihaleler = db.Ihaleler.Where(x => x.IhalelerId == id).SingleOrDefault();
                Ihaleler.IhalelerAciklama = h.IhalelerAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}