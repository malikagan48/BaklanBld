using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("EmlakVergisi")]
    public class EmlakVergisi
    {
        [Key]
        public int EmlakVergisiId { get; set; }
        [Required]
        [DisplayName("EmlakVergisi Açıklama")]
        public string EmlakVergisiAciklama { get; set; }

    }
}