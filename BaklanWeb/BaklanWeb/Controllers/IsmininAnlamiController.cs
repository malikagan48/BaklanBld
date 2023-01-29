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
    public class IsmininAnlamiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  IsmininAnlami
        public ActionResult Index()
        {
            var h = db.IsmininAnlami.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.IsmininAnlami.Where(x => x.IsmininAnlamiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, IsmininAnlami h)
        {
            if (ModelState.IsValid)
            {
                var IsmininAnlami = db.IsmininAnlami.Where(x => x.IsmininAnlamiId == id).SingleOrDefault();
                IsmininAnlami.IsmininAnlamiAciklama = h.IsmininAnlamiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}