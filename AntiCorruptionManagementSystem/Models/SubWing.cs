using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_SubWing")]
    public class SubWing
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "WingId cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }

        public virtual Wing Wings { get; set; }
    }
}