using System.ComponentModel.DataAnnotations;

namespace ControlePecasWeb_v0.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
