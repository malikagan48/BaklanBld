using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Nüfusu")]
    public class Nüfusu
    {
        [Key]
        public int NüfusuId { get; set; }
        [Required]
        [DisplayName("Nüfusu Açıklama")]
        public string NüfusuAciklama { get; set; }

    }
}