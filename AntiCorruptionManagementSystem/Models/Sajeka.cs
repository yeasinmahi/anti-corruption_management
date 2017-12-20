﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_Sajeka")]
    public class Sajeka
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Wing cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public virtual Wing Wings { get; set; }
    }
}