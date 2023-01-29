using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Ekonomi")]
    public class Ekonomi
    {
        [Key]
        public int EkonomiId { get; set; }
        [Required]
        [DisplayName("Ekonomi Açıklama")]
        public string EkonomiAciklama { get; set; }

    }
}