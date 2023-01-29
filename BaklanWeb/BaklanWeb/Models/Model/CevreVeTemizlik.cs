using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("CevreVeTemizlik")]
    public class CevreVeTemizlik
    {
        [Key]
        public int CevreVeTemizlikId { get; set; }
        [Required]
        [DisplayName("CevreVeTemizlik Açıklama")]
        public string CevreVeTemizlikAciklama { get; set; }

    }
}