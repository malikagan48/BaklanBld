using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Muhtarlik")]
    public class Muhtarlik
    {
        [Key]
        public int MuhtarlikId { get; set; }
        [Required]
        [DisplayName("Muhtarlik Açıklama")]
        public string MuhtarlikAciklama { get; set; }

    }
}