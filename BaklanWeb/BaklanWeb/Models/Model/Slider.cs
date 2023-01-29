using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BaklanWeb.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [DisplayName("Slider Başlık"), StringLength(70, ErrorMessage = "70 karekter olmalıdır")]
        public string SliderBaslik { get; set; }
        [DisplayName("Slider Açıklama"), StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
        public string SliderAciklama { get; set; }
        [DisplayName("Slider Resim"), StringLength(250)]
        public string SliderResimURL { get; set; }

    }
}