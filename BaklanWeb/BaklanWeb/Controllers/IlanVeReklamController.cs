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
    public class IlanVeReklamController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  IlanVeReklam
        public ActionResult Index()
        {
            var h = db.IlanVeReklam.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.IlanVeReklam.Where(x => x.IlanVeReklamId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, IlanVeReklam h)
        {
            if (ModelState.IsValid)
            {
                var IlanVeReklam = db.IlanVeReklam.Where(x => x.IlanVeReklamId == id).SingleOrDefault();
                IlanVeReklam.IlanVeReklamAciklama = h.IlanVeReklamAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}