using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{

        [Table("FotoGaleriKategori")]
        public class FotoGaleriKategori
        {
            [Key]
            public int FotoGaleriKategoriId { get; set; }
            [Required, StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
            public string FotoGaleriKategoriAd { get; set; }
            public string FotoGaleriKategoriAciklama { get; set; }
            public ICollection<FotoGaleri> FotoGaleris { get; set; }

        }
    }
