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
    public class BaskanHakkindaController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();

        // GET: BaskanHakkinda
        public ActionResult Index()
        {
            var h = db.BaskanHakkinda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.BaskanHakkinda.Where(x => x.BaskanHakkindaId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, BaskanHakkinda h)
        {
            if (ModelState.IsValid)
            {
                var BaskanHakkinda = db.BaskanHakkinda.Where(x => x.BaskanHakkindaId == id).SingleOrDefault();
                BaskanHakkinda.BaskanHakkindaAciklama = h.BaskanHakkindaAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(h);
        }
    }
}