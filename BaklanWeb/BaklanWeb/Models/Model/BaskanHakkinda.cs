using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("BaskanHakkinda")]
    public class BaskanHakkinda
    {
        [Key]
        public int BaskanHakkindaId { get; set; }
        [Required]
        [DisplayName("BaskanHakkinda Açıklama")]
        public string BaskanHakkindaAciklama { get; set; }

    }
}