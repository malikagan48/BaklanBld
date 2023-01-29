using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("EvlenmeIsleri")]
    public class EvlenmeIsleri
    {
        [Key]
        public int EvlenmeIsleriId { get; set; }
        [Required]
        [DisplayName("EvlenmeIsleri Açıklama")]
        public string EvlenmeIsleriAciklama { get; set; }

    }
}