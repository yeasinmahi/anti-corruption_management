using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_Accuser")]
    public class Accuser
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}