using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("EskiBaskanlar")]
    public class EskiBaskanlar
    {
        [Key]
        public int EskiBaskanlarId { get; set; }
        [Required]
        [DisplayName("EskiBaskanlar Açıklama")]
        public string EskiBaskanlarAciklama { get; set; }

    }
}