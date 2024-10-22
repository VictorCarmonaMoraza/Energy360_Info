using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Energy360_Info.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string NameUser { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }
    }
}
