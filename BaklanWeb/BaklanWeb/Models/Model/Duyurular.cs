using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Duyurular")]
    public class Duyurular
    {
        [Key]
        public int DuyurularId { get; set; }
        [DisplayName("Duyurular Başlık"), StringLength(200, ErrorMessage = "200 karekter olmalıdır")]
        public string DuyurularBaslik { get; set; }
        [DisplayName("Duyurular Açıklama"), StringLength(15000, ErrorMessage = "15000 karekter olmalıdır")]
        public string DuyurularAciklama { get; set; }
        [DisplayName("Duyurular Resim"), StringLength(250)]
        public string DuyurularResimURL { get; set; }
    }
}