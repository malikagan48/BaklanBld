using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Egitim")]
    public class Egitim
    {
        [Key]
        public int EgitimId { get; set; }
        [Required]
        [DisplayName("Egitim Açıklama")]
        public string EgitimAciklama { get; set; }

    }
}