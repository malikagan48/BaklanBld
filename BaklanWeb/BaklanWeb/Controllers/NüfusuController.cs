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
    public class NüfusuController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Nüfusu
        public ActionResult Index()
        {
            var h = db.Nüfusu.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Nüfusu.Where(x => x.NüfusuId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Nüfusu h)
        {
            if (ModelState.IsValid)
            {
                var Nüfusu = db.Nüfusu.Where(x => x.NüfusuId == id).SingleOrDefault();
                Nüfusu.NüfusuAciklama = h.NüfusuAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}