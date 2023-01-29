using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("BaskanMesaj")]
    public class BaskanMesaj
    {
        [Key]
        public int BaskanMesajId { get; set; }
        [Required]
        [DisplayName("BaskanMesaj Açıklama")]
        public string BaskanMesajAciklama { get; set; }

    }
}