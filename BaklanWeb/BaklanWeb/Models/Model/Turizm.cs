using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Turizm")]
    public class Turizm
    {
        [Key]
        public int TurizmId { get; set; }
        [Required,StringLength(150,ErrorMessage ="150 karekter olabilir")]
        [DisplayName("Turizm Başlık")]
        public string TurizmBaslik { get; set; }
        [DisplayName("Turizm Açıklama")]
        public string TurizmAciklama { get; set; }
        [DisplayName("Turizm Resim")]
        public string TurizmResimURL { get; set; }
        public int? TurizmKategoriId { get; set; }
        public TurizmKategori TurizmKategori { get; set; }
    }
}