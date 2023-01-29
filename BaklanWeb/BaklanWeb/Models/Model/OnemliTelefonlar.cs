using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("OnemliTelefonlar")]
    public class OnemliTelefonlar
    {
        [Key]
        public int OnemliTelefonlarId { get; set; }
        [Required]
        [DisplayName("OnemliTelefonlar Açıklama")]
        public string OnemliTelefonlarAciklama { get; set; }

    }
}