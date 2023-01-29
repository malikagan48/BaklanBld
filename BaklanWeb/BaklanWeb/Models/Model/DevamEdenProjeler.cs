using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
       [Table("DevamEdenProjeler")]
    public class DevamEdenProjeler
    {
        [Key]
        public int DevamEdenProjelerId { get; set; }
        [Required,StringLength(150,ErrorMessage ="150 karekter olabilir")]
        [DisplayName("DevamEdenProjeler Başlık")]
        public string DevamEdenProjelerBaslik { get; set; }
        [DisplayName("DevamEdenProjeler Açıklama")]
        public string DevamEdenProjelerAciklama { get; set; }
        [DisplayName("DevamEdenProjeler Resim")]
        public string DevamEdenProjelerResimURL { get; set; }
        public int? DevamEdenProjelerKategoriId { get; set; }
        public DevamEdenProjelerKategori DevamEdenProjelerKategori { get; set; }
    }
}