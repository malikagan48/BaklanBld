using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BaklanWeb.Models.Model;
using BaklanWeb.Models.DataContext;
using BaklanWeb.Models;

namespace BaklanWeb.Controllers
{
    public class AdminController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Admin
        [Route("yonetimpaneli")]
        
            public ActionResult Index()
        {
            ViewBag.DevamEdenProjelerSay = db.DevamEdenProjeler.Count();
            ViewBag.TamamlananProjelerSay = db.TamamlananProjeler.Count();
            ViewBag.FotoGaleriSay = db.FotoGaleri.Count();
            ViewBag.MudurluklerSay = db.Mudurlukler.Count();
            ViewBag.TurizmSay = db.Turizm.Count();
            ViewBag.VideoGaleriSay = db.VideoGaleri.Count();


            var sorgu = db.DevamEdenProjeler.ToList();
            return View(sorgu);
        }
        [Route("yonetimpaneli/giris")]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login.Eposta == admin.Eposta && login.Sifre ==admin.Sifre)
            {
                Session["adminid"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı yada şifre yanlış";
            return View(admin);

        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }

 


    }
}