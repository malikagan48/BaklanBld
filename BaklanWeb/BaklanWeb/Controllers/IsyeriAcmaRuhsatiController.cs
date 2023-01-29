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
    public class IsyeriAcmaRuhsatiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  IsyeriAcmaRuhsati
        public ActionResult Index()
        {
            var h = db.IsyeriAcmaRuhsati.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.IsyeriAcmaRuhsati.Where(x => x.IsyeriAcmaRuhsatiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, IsyeriAcmaRuhsati h)
        {
            if (ModelState.IsValid)
            {
                var IsyeriAcmaRuhsati = db.IsyeriAcmaRuhsati.Where(x => x.IsyeriAcmaRuhsatiId == id).SingleOrDefault();
                IsyeriAcmaRuhsati.IsyeriAcmaRuhsatiAciklama = h.IsyeriAcmaRuhsatiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}