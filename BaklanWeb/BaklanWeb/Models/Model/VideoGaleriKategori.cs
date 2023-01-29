using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{


       [Table("VideoGaleriKategori")]
    public class VideoGaleriKategori
    {
        [Key]
        public int VideoGaleriKategoriId { get; set; }
        [Required, StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
        public string VideoGaleriKategoriAd { get; set; }
        public string VideoGaleriKategoriAciklama { get; set; }
        public ICollection<VideoGaleri> VideoGaleris { get; set; }

    }
}