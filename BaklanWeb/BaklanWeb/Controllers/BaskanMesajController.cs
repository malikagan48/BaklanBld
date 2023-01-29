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
    public class BaskanMesajController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  BaskanMesaj
        public ActionResult Index()
        {
            var h = db. BaskanMesaj.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db. BaskanMesaj.Where(x => x. BaskanMesajId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,  BaskanMesaj h)
        {
            if (ModelState.IsValid)
            {
                var  BaskanMesaj = db. BaskanMesaj.Where(x => x. BaskanMesajId == id).SingleOrDefault();
                 BaskanMesaj. BaskanMesajAciklama = h. BaskanMesajAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}