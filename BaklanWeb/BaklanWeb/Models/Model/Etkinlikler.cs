using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Etkinlikler")]
    public class Etkinlikler
    {
        [Key]
        public int EtkinliklerId { get; set; }
        [Required]
        [DisplayName("Etkinlikler Açıklama")]
        public string EtkinliklerAciklama { get; set; }

    }
}