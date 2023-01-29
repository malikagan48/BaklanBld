using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("HizmetStandarti")]
    public class HizmetStandarti
    {
        [Key]
        public int HizmetStandartiId { get; set; }
        [Required]
        [DisplayName("HizmetStandarti Açıklama")]
        public string HizmetStandartiAciklama { get; set; }

    }
}