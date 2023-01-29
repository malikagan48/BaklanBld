using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
     [Table("DevamEdenProjelerKategori")]
    public class DevamEdenProjelerKategori
    {
        [Key]
        public int DevamEdenProjelerKategoriId { get; set; }
        [Required, StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
        public string DevamEdenProjelerKategoriAd { get; set; }
        public string DevamEdenProjelerKategoriAciklama { get; set; }
        public ICollection<DevamEdenProjeler> DevamEdenProjelers { get; set; }

    }

}