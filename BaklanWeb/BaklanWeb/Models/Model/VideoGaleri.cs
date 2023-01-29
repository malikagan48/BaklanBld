using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("VideoGaleri")]
    public class VideoGaleri
    {
        [Key]
        public int VideoGaleriId { get; set; }
        [Required, StringLength(150, ErrorMessage = "150 karekter olabilir")]
        [DisplayName("VideoGaleri Başlık")]
        public string VideoGaleriBaslik { get; set; }
        [DisplayName("VideoGaleri Açıklama")]
        public string VideoGaleriAciklama { get; set; }
        [DisplayName("VideoGaleri Resim")]
        public string VideoGaleriResimURL { get; set; }
        public int? VideoGaleriKategoriId { get; set; }
        public VideoGaleriKategori VideoGaleriKategori { get; set; }
    }
}