using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("CografiYapisi")]
    public class CografiYapisi
    {
        [Key]
        public int CografiYapisiId { get; set; }
        [Required]
        [DisplayName("CografiYapisi Açıklama")]
        public string CografiYapisiAciklama { get; set; }

    }
}