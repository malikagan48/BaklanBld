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
    public class BaklanBelediyeSporKlubüController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET: BaklanBelediyeSporKlubü
        public ActionResult Index()
        {
            var h = db.BaklanBelediyeSporKlubü.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.BaklanBelediyeSporKlubü.Where(x => x.BaklanBelediyeSporKlubüId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, BaklanBelediyeSporKlubü h)
        {
            if (ModelState.IsValid)
            {
                var baklanBelediyeSporKlubü = db.BaklanBelediyeSporKlubü.Where(x => x.BaklanBelediyeSporKlubüId == id).SingleOrDefault();
                baklanBelediyeSporKlubü.BaklanBelediyeSporKlubüAciklama = h.BaklanBelediyeSporKlubüAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }

     
    
    }
    }
