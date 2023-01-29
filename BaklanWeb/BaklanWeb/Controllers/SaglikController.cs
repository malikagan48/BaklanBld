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
    public class SaglikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  Saglik
        public ActionResult Index()
        { 
            
            var h = db.Saglik.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Saglik.Where(x => x.SaglikId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Saglik h)
        {
            if (ModelState.IsValid)
            {
                var Saglik = db.Saglik.Where(x => x.SaglikId == id).SingleOrDefault();
                Saglik.SaglikAciklama = h.SaglikAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}