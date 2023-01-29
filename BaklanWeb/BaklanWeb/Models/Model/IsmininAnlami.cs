using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("IsmininAnlami")]
    public class IsmininAnlami
    {
        [Key]
        public int IsmininAnlamiId { get; set; }
        [Required]
        [DisplayName("IsmininAnlami Açıklama")]
        public string IsmininAnlamiAciklama { get; set; }

    }
}