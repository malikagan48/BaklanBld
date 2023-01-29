using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Saglik")]
    public class Saglik
    {
        [Key]
        public int SaglikId { get; set; }
        [Required]
        [DisplayName("Saglik Açıklama")]
        public string SaglikAciklama { get; set; }

    }
}