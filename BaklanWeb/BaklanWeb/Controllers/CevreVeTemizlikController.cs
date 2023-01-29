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
    public class CevreVeTemizlikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  CevreVeTemizlik
        public ActionResult Index()
        {
            var h = db.CevreVeTemizlik.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.CevreVeTemizlik.Where(x => x.CevreVeTemizlikId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, CevreVeTemizlik h)
        {
            if (ModelState.IsValid)
            {
                var CevreVeTemizlik = db.CevreVeTemizlik.Where(x => x.CevreVeTemizlikId == id).SingleOrDefault();
                CevreVeTemizlik.CevreVeTemizlikAciklama = h.CevreVeTemizlikAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}