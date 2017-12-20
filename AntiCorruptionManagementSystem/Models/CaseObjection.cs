using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_CaseObjection")]
    public class CaseObjection
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        public string ERNumber { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation cannot be empty")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yy}",
        ApplyFormatInEditMode = true)]
        public DateTime DateofObjection { get; set; }
        
        [Required(ErrorMessage = "Objection Details cannot be empty")]
        public string ObjectionDetails { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        public string InquiryMemorandumNumber { get; set; }

        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yy}",
        ApplyFormatInEditMode = true)]
        public DateTime InquiryDate { get; set; }

        
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Wing cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }

        [Required(ErrorMessage = "Employee cannot be empty")]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        public virtual Wing Wings { get; set; }
        public virtual Employee Employees { get; set; }
    }
}