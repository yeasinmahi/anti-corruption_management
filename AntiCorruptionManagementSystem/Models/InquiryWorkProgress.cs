using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_InquiryWorkProgress")]
    public class InquiryWorkProgress
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        public string FileNumber { get; set; }

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

        
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Accuser cannot be empty")]
        [ForeignKey("Accusers")]
        public int AccuserId { get; set; }

        [Required(ErrorMessage = "Wing cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }

        [Required(ErrorMessage = "Sajeka cannot be empty")]
        [ForeignKey("Sajekas")]
        public int SajekaId { get; set; }


        [Required(ErrorMessage = "Employee cannot be empty")]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        public virtual Wing Wings { get; set; }
        public virtual Sajeka Sajekas { get; set; }
        public virtual Accuser Accusers { get; set; }
        public virtual Employee Employees { get; set; }
    }
}