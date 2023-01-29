using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("BaklanBelediyeSporKlubü")]
    public class BaklanBelediyeSporKlubü
    {
        [Key]
        public int BaklanBelediyeSporKlubüId { get; set; }
        [Required]
        [DisplayName("BaklanBelediyeSporKlubü Açıklama")]
        public string BaklanBelediyeSporKlubüAciklama { get; set; }

    }
}