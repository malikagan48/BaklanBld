using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("TatilCalismaRuhsati")]
    public class TatilCalismaRuhsati
    {
        [Key]
        public int TatilCalismaRuhsatiId { get; set; }
        [Required]
        [DisplayName("TatilCalismaRuhsati Açıklama")]
        public string TatilCalismaRuhsatiAciklama { get; set; }

    }
}