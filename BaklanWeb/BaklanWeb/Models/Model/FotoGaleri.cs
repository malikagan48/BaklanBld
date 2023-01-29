using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("FotoGaleri")]
    public class FotoGaleri
    {
        [Key]
        public int FotoGaleriId { get; set; }
        [Required,StringLength(150,ErrorMessage ="150 karekter olabilir")]
        [DisplayName("FotoGaleri Başlık")]
        public string FotoGaleriBaslik { get; set; }
        [DisplayName("FotoGaleri Açıklama")]
        public string FotoGaleriAciklama { get; set; }
        [DisplayName("FotoGaleri Resim")]
        public string FotoGaleriResimURL { get; set; }
        public int? FotoGaleriKategoriId { get; set; }
        public FotoGaleriKategori FotoGaleriKategori { get; set; }

    }
}