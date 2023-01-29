using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Mudurlukler")]
    public class Mudurlukler
    {
        [Key]
        public int MudurluklerId { get; set; }
        [Required,StringLength(150,ErrorMessage ="150 karekter olabilir")]
        [DisplayName("Mudurlukler Başlık")]
        public string MudurluklerBaslik { get; set; }
        [DisplayName("Mudurlukler Açıklama")]
        public string MudurluklerAciklama { get; set; }
        [DisplayName("Mudurlukler Resim")]
        public string MudurluklerResimURL { get; set; }
    }
}