using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_InquiryWorkProgress")]
    public class InquiryWorkProgress
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        public int FileNumber { get; set; }

        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yy}",
        ApplyFormatInEditMode = true)]
        public DateTime DateofInquiryOrder { get; set; }
        
        [Required(ErrorMessage = "Description cannot be empty")]
        public string ComplainDescription  { get; set; }

        [Required(ErrorMessage = "Current Status cannot be empty")]
        public string CurrentStatus { get; set; }

        [Required(ErrorMessage = "Remarks cannot be empty")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "IsActive cannot be empty")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "AccuserId cannot be empty")]
        [ForeignKey("Accusers")]
        public int AccuserId { get; set; }

        [Required(ErrorMessage = "WingId cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }

        [Required(ErrorMessage = "SubWingId cannot be empty")]
        [ForeignKey("SubWings")]
        public int SubWingId { get; set; }


        [Required(ErrorMessage = "EmployeeId cannot be empty")]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        public virtual Wing Wings { get; set; }
        public virtual SubWing SubWings { get; set; }
        public virtual Accuser Accusers { get; set; }
        public virtual Employee Employees { get; set; }
    }
}