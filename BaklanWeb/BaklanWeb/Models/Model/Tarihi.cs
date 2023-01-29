using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("Tarihi")]
    public class Tarihi
    {
        [Key]
        public int TarihiId { get; set; }
        [Required]
        [DisplayName("Tarihi Açıklama")]
        public string TarihiAciklama { get; set; }

    }
}