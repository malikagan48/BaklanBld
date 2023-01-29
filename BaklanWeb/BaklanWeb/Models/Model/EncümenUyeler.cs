using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("EncümenUyeler")]
    public class EncümenUyeler
    {
        [Key]
        public int EncümenUyelerId { get; set; }
        [Required]
        [DisplayName("EncümenUyeler Açıklama")]
        public string EncümenUyelerAciklama { get; set; }

    }
}