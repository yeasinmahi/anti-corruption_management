using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntiCorruptionManagementSystem.Models
{
    [Table("tbl_Wing")]
    public class Wing
    {
        [Key]
        public int Sl { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
    }
}