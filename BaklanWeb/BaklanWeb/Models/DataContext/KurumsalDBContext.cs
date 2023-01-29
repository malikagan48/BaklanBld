using BaklanWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.DataContext
{
    public class KurumsalDBContext:DbContext
    {
        public KurumsalDBContext():base("KurumsalWebDB")
        {
            
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BaklanBelediyeSporKlubü>BaklanBelediyeSporKlubü { get; set; }
        public DbSet<BaskanHakkinda> BaskanHakkinda { get; set; }
        public DbSet<BaskanMesaj> BaskanMesaj { get; set; }
        public DbSet<CevreVeTemizlik> CevreVeTemizlik { get; set; }
        public DbSet<CografiYapisi> CografiYapisi { get; set; }
        public DbSet<DevamEdenProjeler> DevamEdenProjeler { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<Egitim> Egitim { get; set; }
        public DbSet<Ekonomi> Ekonomi { get; set; }
        public DbSet<EmlakVergisi> EmlakVergisi { get; set; }
        public DbSet<EncümenUyeler> EncümenUyeler { get; set; }
        public DbSet<EskiBaskanlar> EskiBaskanlar { get; set; }
        public DbSet<Etkinlikler> Etkinlikler { get; set; }
        public DbSet<EvlenmeIsleri> EvlenmeIsleri { get; set; }
        public DbSet<Festivaller> Festivaller { get; set; }
        public DbSet<FotoGaleri> FotoGaleri { get; set; }
        public DbSet<HaberlerSlider> HaberlerSlider { get; set; }
        public DbSet<HizmetStandarti> HizmetStandarti { get; set; }
        public DbSet<Ihaleler> Ihaleler { get; set; }
        public DbSet<IlanVeReklam> IlanVeReklam { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<InsaatRuhsati> InsaatRuhsati { get; set; }
        public DbSet<IsmininAnlami> IsmininAnlami { get; set; }
        public DbSet<IsyeriAcmaRuhsati> IsyeriAcmaRuhsati { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<MeclisUyeleri> MeclisUyeleri { get; set; }
        public DbSet<Mudurlukler> Mudurlukler { get; set; }
        public DbSet<Muhtarlik> Muhtarlik { get; set; }
        public DbSet<Nüfusu> Nüfusu { get; set; }
        public DbSet<OnemliTelefonlar> OnemliTelefonlar { get; set; }
        public DbSet<TamamlananProjeler> TamamlananProjeler { get; set; }
        public DbSet<Tarihi> Tarihi { get; set; }
        public DbSet<TatilCalismaRuhsati> TatilCalismaRuhsati { get; set; }
        public DbSet<Turizm> Turizm { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<TurizmKategori> TurizmKategori { get; set; }
        public DbSet<VideoGaleri> VideoGaleri { get; set; }

        public System.Data.Entity.DbSet<BaklanWeb.Models.Model.Saglik> Saglik { get; set; }

        public System.Data.Entity.DbSet<BaklanWeb.Models.Model.DevamEdenProjelerKategori> DevamEdenProjelerKategoris { get; set; }

        public System.Data.Entity.DbSet<BaklanWeb.Models.Model.FotoGaleriKategori> FotoGaleriKategoris { get; set; }

        public System.Data.Entity.DbSet<BaklanWeb.Models.Model.TamamlananProjelerKategori> TamamlananProjelerKategoris { get; set; }

        public System.Data.Entity.DbSet<BaklanWeb.Models.Model.VideoGaleriKategori> VideoGaleriKategoris { get; set; }
    }
}