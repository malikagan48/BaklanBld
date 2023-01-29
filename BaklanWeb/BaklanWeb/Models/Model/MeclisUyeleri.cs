using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("MeclisUyeleri")]
    public class MeclisUyeleri
    {
        [Key]
        public int MeclisUyeleriId { get; set; }
        [Required]
        [DisplayName("MeclisUyeleri Açıklama")]
        public string MeclisUyeleriAciklama { get; set; }

    }
}