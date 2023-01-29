using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("TamamlananProjelerKategori")]
    public class TamamlananProjelerKategori
    {
        [Key]
        public int TamamlananProjelerKategoriId { get; set; }
        [Required, StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
        public string TamamlananProjelerKategoriAd { get; set; }
        public string TamamlananProjelerKategoriAciklama { get; set; }
        public ICollection<TamamlananProjeler> TamamlananProjelers { get; set; }

    }
}