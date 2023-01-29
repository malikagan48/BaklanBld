using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Festivaller")]
    public class Festivaller
    {
        [Key]
        public int FestivallerId { get; set; }
        [Required]
        [DisplayName("Festivaller Açıklama")]
        public string FestivallerAciklama { get; set; }

    }
}