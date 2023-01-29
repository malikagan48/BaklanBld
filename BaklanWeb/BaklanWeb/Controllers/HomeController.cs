using BaklanWeb.Models.DataContext;
using BaklanWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace BaklanWeb.Controllers
{
    public class HomeController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        [Route("")]
        [Route("Anasayfa")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Mudurlukler")]

        public ActionResult Mudurlukler()
        {
            return View(db.Mudurlukler.ToList().OrderByDescending(x => x.MudurluklerId));
        }



        [Route("DevamEdenProjeler")]
        public ActionResult DevamEdenProjeler()
        {
            return View(db.DevamEdenProjeler.Include("DevamEdenProjelerKategori").OrderByDescending(x => x.DevamEdenProjelerId));
        }
        [Route("DevamEdenProjeler/{kategoriad}/{id:int}")]
        public ActionResult DevamEdenProjelerPartial(int id)
        {
            var b = db.DevamEdenProjeler.Include("DevamEdenProjelerKategori").OrderByDescending(x => x.DevamEdenProjelerId).Where(x => x.DevamEdenProjelerKategori.DevamEdenProjelerKategoriId == id);
            return View(b);
        }
        public ActionResult DevamEdenProjelerKategori()
        {
            return PartialView(db.DevamEdenProjelerKategoris.Include("DevamEdenProjelers").ToList().OrderBy(x => x.DevamEdenProjelerKategoriId));

        }





        [Route("TamamlananProjeler")]

        public ActionResult TamamlananProjeler()
        {
            return View(db.TamamlananProjeler.Include("TamamlananProjelerKategori").OrderByDescending(x => x.TamamlananProjelerId));
        }
        [Route("TamamlananProjeler/{kategoriad}/{id:int}")]
        public ActionResult TamamlananProjelerPartial(int id)
        {
            var b = db.TamamlananProjeler.Include("TamamlananProjelerKategori").OrderByDescending(x => x.TamamlananProjelerId).Where(x => x.TamamlananProjelerKategori.TamamlananProjelerKategoriId == id);
            return View(b);
        }
        public ActionResult TamamlananProjelerKategori()
        {
            return PartialView(db.TamamlananProjelerKategoris.Include("TamamlananProjelers").ToList().OrderBy(x => x.TamamlananProjelerKategoriId));

        }




        [Route("FotoGaleri")]

        public ActionResult FotoGaleri()
        {
            return View(db.FotoGaleri.Include("FotoGaleriKategori").OrderByDescending(x => x.FotoGaleriId));
        }
        [Route("FotoGaleri/{kategoriad}/{id:int}")]
        public ActionResult FotoGaleriPartial(int id)
        {
            var b = db.FotoGaleri.Include("FotoGaleriKategori").OrderByDescending(x => x.FotoGaleriId).Where(x => x.FotoGaleriKategori.FotoGaleriKategoriId == id);
            return View(b);
        }
        public ActionResult FotoGaleriKategori()
        {
            return PartialView(db.FotoGaleriKategoris.Include("FotoGaleris").ToList().OrderBy(x => x.FotoGaleriKategoriId));

        }




        [Route("VideoGaleri")]

        public ActionResult VideoGaleri()
        {
            return View(db.VideoGaleri.Include("VideoGaleriKategori").OrderByDescending(x => x.VideoGaleriId));
        }
        [Route("VideoGaleri/{kategoriad}/{id:int}")]
        public ActionResult VideoGaleriPartial(int id)
        {
            var b = db.VideoGaleri.Include("VideoGaleriKategori").OrderByDescending(x => x.VideoGaleriId).Where(x => x.VideoGaleriKategori.VideoGaleriKategoriId == id);
            return View(b);
        }
        public ActionResult VideoGaleriKategori()
        {
            return PartialView(db.VideoGaleriKategoris.Include("VideoGaleris").ToList().OrderBy(x => x.VideoGaleriKategoriId));

        }


        [Route("Turizm")]
        public ActionResult Turizm()
        {
            return View(db.Turizm.Include("TurizmKategori").OrderByDescending(x => x.TurizmId));
        }
        [Route("Turizm/{kategoriad}/{id:int}")]
        public ActionResult TurizmKategoriPartial(int id)
        {
            var b = db.Turizm.Include("TurizmKategori").OrderByDescending(x => x.TurizmId).Where(x => x.TurizmKategori.TurizmKategoriId == id);
            return View(b);
        }
        public ActionResult TurizmKategori()
        {
            return PartialView(db.TurizmKategori.Include("Turizms").ToList().OrderBy(x => x.TurizmKategoriId));

        }



        [Route("Duyurular")]

        public ActionResult Duyurular(int Sayfa = 1)
        {
            return View(db.Duyurular.OrderByDescending(x => x.DuyurularId).ToPagedList(Sayfa,5));
        }
        [Route("Haberler")]

        public ActionResult Haberler(int Sayfa = 1)
        {
            return View(db.HaberlerSlider.OrderByDescending(x => x.HaberlerSliderId).ToPagedList(Sayfa, 5));
        }
        public ActionResult DuyurularPartial()
        {
            return View(db.Duyurular.ToList().OrderByDescending(x => x.DuyurularId));
        }
        public ActionResult HaberlerPartial()
        {
            return View(db.HaberlerSlider.ToList().OrderByDescending(x => x.HaberlerSliderId));
        }
        [Route("HaberlerPost/{baslik}-{id:int}")]
        public ActionResult HaberlerDetay(int id)
        {
            var b = db.HaberlerSlider.Where(x => x.HaberlerSliderId == id).SingleOrDefault();
            return View(b);
        }
        [Route("DuyurularPost/{baslik}-{id:int}")]
        public ActionResult DuyurularDetay(int id)
        {
            var b = db.Duyurular.Where(x => x.DuyurularId == id).SingleOrDefault();
            return View(b);
        }

        [Route("BaklanBelediyeSporKlubü")]

        public ActionResult BaklanBelediyeSporKlubü()
        {
            return View(db.BaklanBelediyeSporKlubü.SingleOrDefault());
        }
        [Route("BaskanHakkinda")]
        public ActionResult BaskanHakkinda()
        {
            return View(db.BaskanHakkinda.SingleOrDefault());
        }
        [Route("BaskanMesaj")]

        public ActionResult BaskanMesaj()
        {
            return View(db.BaskanMesaj.SingleOrDefault());
        }
        [Route("CevreVeTemizlik")]

        public ActionResult CevreVeTemizlik()
        {
            return View(db.CevreVeTemizlik.SingleOrDefault());
        }
        [Route("CografiYapisi")]

        public ActionResult CografiYapisi()
        {
            return View(db.CografiYapisi.SingleOrDefault());
        }
        [Route("Egitim")]

        public ActionResult Egitim()
        {
            return View(db.Egitim.SingleOrDefault());
        }
        [Route("Ekonomi")]

        public ActionResult Ekonomi()
        {
            return View(db.Ekonomi.SingleOrDefault());
        }
        [Route("EncümenUyeler")]
        public ActionResult EncümenUyeler()
        {
            return View(db.EncümenUyeler.SingleOrDefault());
        }
        [Route("EskiBaskanlar")]

        public ActionResult EskiBaskanlar()
        {
            return View(db.EskiBaskanlar.SingleOrDefault());
        }
        [Route("Etkinlikler")]

        public ActionResult Etkinlikler()
        {
            return View(db.Etkinlikler.SingleOrDefault());
        }
        [Route("EvlenmeIsleri")]

        public ActionResult EvlenmeIsleri()
        {
            return View(db.EvlenmeIsleri.SingleOrDefault());
        }
        [Route("EmlakVergisi")]

        public ActionResult EmlakVergisi()
        {
            return View(db.EmlakVergisi.SingleOrDefault());
        }
        [Route("Festivaller")]

        public ActionResult Festivaller()
        {
            return View(db.Festivaller.SingleOrDefault());
        }
        [Route("HizmetStandarti")]

        public ActionResult HizmetStandarti()
        {
            return View(db.HizmetStandarti.SingleOrDefault());
        }
        [Route("Ihaleler")]

        public ActionResult Ihaleler()
        {
            return View(db.Ihaleler.SingleOrDefault());
        }
        [Route("IlanVeReklam")]

        public ActionResult IlanVeReklam()
        {
            return View(db.IlanVeReklam.SingleOrDefault());
        }
        [Route("InsaatRuhsati")]

        public ActionResult InsaatRuhsati()
        {
            return View(db.InsaatRuhsati.SingleOrDefault());
        }
        [Route("IsmininAnlami")]

        public ActionResult IsmininAnlami()
        {
            return View(db.IsmininAnlami.SingleOrDefault());
        }
        [Route("IsyeriAcmaRuhsati")]

        public ActionResult IsyeriAcmaRuhsati()
        {
            return View(db.IsyeriAcmaRuhsati.SingleOrDefault());
        }
        [Route("MeclisUyeleri")]

        public ActionResult MeclisUyeleri()
        {
            return View(db.MeclisUyeleri.SingleOrDefault());
        }
        [Route("Muhtarlik")]

        public ActionResult Muhtarlik()
        {
            return View(db.Muhtarlik.SingleOrDefault());
        }
        [Route("Nüfusu")]

        public ActionResult Nüfusu()
        {
            return View(db.Nüfusu.SingleOrDefault());
        }
        [Route("OnemliTelefonlar")]

        public ActionResult OnemliTelefonlar()
        {
            return View(db.OnemliTelefonlar.SingleOrDefault());
        }
        [Route("Saglik")]

        public ActionResult Saglik()
        {
            return View(db.Saglik.SingleOrDefault());
        }
        [Route("Tarihi")]

        public ActionResult Tarihi()
        {
            return View(db.Tarihi.SingleOrDefault());
        }
        [Route("TatilCalismaRuhsati")]

        public ActionResult TatilCalismaRuhsati()
        {
            return View(db.TatilCalismaRuhsati.SingleOrDefault());
        }

        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.SliderId));
        }
        public ActionResult FooterPartial()
        {


            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();


            return PartialView();
        }
        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            return View(db.Iletisim.SingleOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "kurumsalwebsitesi048@gmail.com";
                WebMail.Password = "xlijqlqwrocdfxud";
                WebMail.SmtpPort = 587;
                WebMail.Send("kurumsalwebsitesi048@gmail.com", konu, email + " - " + mesaj);
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";
                Response.Redirect("/iletisim");

            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            }
            return View();
        }
    }
}