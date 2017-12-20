using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_Employee")]
    public class Employee
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation cannot be empty")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Employee Id cannot be empty")]
        public string EmployeeId { get; set; }

        
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Wing cannot be empty")]
        [ForeignKey("Wings")]
        public int WingId { get; set; }

        [Required(ErrorMessage = "Sajeka cannot be empty")]
        [ForeignKey("Sajekas")]
        public int SajekaId { get; set; }

        public virtual Wing Wings { get; set; }
        public virtual Sajeka Sajekas { get; set; }
    }
}