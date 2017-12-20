using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_AccusedPersonInfo")]
    public class AccusedPersonInfo
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation cannot be empty")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yy}",
        ApplyFormatInEditMode = true)]
        public DateTime DateofCaseSubmission { get; set; }
        
        [Required(ErrorMessage = "Objection Details cannot be empty")]
        public string CaseShortDescription { get; set; }
        
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Case cannot be empty")]
        [ForeignKey("Cases")]
        public int CaseId { get; set; }

        [Required(ErrorMessage = "Employee cannot be empty")]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        public virtual Case Cases { get; set; }
        public virtual Employee Employees { get; set; }
    }
}