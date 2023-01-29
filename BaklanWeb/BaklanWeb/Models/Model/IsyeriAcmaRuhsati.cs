using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("IsyeriAcmaRuhsati")]
    public class IsyeriAcmaRuhsati
    {
        [Key]
        public int IsyeriAcmaRuhsatiId { get; set; }
        [Required]
        [DisplayName("IsyeriAcmaRuhsati Açıklama")]
        public string IsyeriAcmaRuhsatiAciklama { get; set; }

    }
}