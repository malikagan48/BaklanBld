using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Ihaleler")]
    public class Ihaleler
    {
        [Key]
        public int IhalelerId { get; set; }
        [Required]
        [DisplayName("Ihaleler Açıklama")]
        public string IhalelerAciklama { get; set; }

    }
}