using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("InsaatRuhsati")]
    public class InsaatRuhsati
    {
        [Key]
        public int InsaatRuhsatiId { get; set; }
        [Required]
        [DisplayName("InsaatRuhsati Açıklama")]
        public string InsaatRuhsatiAciklama { get; set; }

    }
}