using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
       [Table("TamamlananProjeler")]
    public class TamamlananProjeler
    {
        [Key]
        public int TamamlananProjelerId { get; set; }
        [Required,StringLength(150,ErrorMessage ="150 karekter olabilir")]
        [DisplayName("TamamlananProjeler Başlık")]
        public string TamamlananProjelerBaslik { get; set; }
        [DisplayName("TamamlananProjeler Açıklama")]
        public string TamamlananProjelerAciklama { get; set; }
        [DisplayName("TamamlananProjeler Resim")]
        public string TamamlananProjelerResimURL { get; set; }
        public int? TamamlananProjelerKategoriId { get; set; }
        public TamamlananProjelerKategori TamamlananProjelerKategori { get; set; }
    }
}