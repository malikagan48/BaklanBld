﻿using BaklanWeb.Models.DataContext;
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
    public class HizmetStandartiController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET:  HizmetStandarti
        public ActionResult Index()
        {
            var h = db.HizmetStandarti.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.HizmetStandarti.Where(x => x.HizmetStandartiId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, HizmetStandarti h)
        {
            if (ModelState.IsValid)
            {
                var HizmetStandarti = db.HizmetStandarti.Where(x => x.HizmetStandartiId == id).SingleOrDefault();
                HizmetStandarti.HizmetStandartiAciklama = h.HizmetStandartiAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}