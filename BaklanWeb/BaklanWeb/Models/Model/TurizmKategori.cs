using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
  
        [Table("TurizmKategori")]
        public class TurizmKategori
        {
            [Key]
            public int TurizmKategoriId { get; set; }
            [Required, StringLength(150, ErrorMessage = "150 karekter olmalıdır")]
            public string TurizmKategoriAd { get; set; }
            public string TurizmKategoriAciklama { get; set; }
            public ICollection<Turizm> Turizms { get; set; }

        }
    }
