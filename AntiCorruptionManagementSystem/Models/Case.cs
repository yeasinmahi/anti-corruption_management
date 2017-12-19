using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_Case")]
    public class Case
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Number cannot be empty")]
        public int CaseNumber { get; set; }

        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yy}",
        ApplyFormatInEditMode = true)]
        public DateTime CaseDate { get; set; }
        
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }

        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yy}",
        ApplyFormatInEditMode = true)]
        public DateTime DateofIOTaken { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string ProgressDetails { get; set; }
        
        [Required(ErrorMessage = "Remarks cannot be empty")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "IsActive cannot be empty")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "WingId cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }
   
        [Required(ErrorMessage = "EmployeeId cannot be empty")]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        public virtual Wing Wings { get; set; }
        public virtual Employee Employees { get; set; }
    }
}