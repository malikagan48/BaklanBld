using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("HaberlerSlider")]
    public class HaberlerSlider
    {
        [Key]
        public int HaberlerSliderId { get; set; }
        [DisplayName("Slider Başlık"),StringLength(200,ErrorMessage ="200 karekter olmalıdır")]
        public string HaberlerBaslik { get; set; }
        [DisplayName("Slider Açıklama"), StringLength(15000, ErrorMessage = "15000 karekter olmalıdır")]
        public string HaberlerAciklama { get; set; }
        [DisplayName("Slider Resim"), StringLength(250)]
        public string HaberlerResimURL { get; set; }

    }
}