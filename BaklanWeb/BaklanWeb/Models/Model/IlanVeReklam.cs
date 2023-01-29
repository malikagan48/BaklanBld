﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BaklanWeb.Models.Model
{
    [Table("IlanVeReklam")]
    public class IlanVeReklam
    {
        [Key]
        public int IlanVeReklamId { get; set; }
        [Required]
        [DisplayName("IlanVeReklam Açıklama")]
        public string IlanVeReklamAciklama { get; set; }

    }
}