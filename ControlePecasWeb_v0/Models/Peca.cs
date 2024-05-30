using System.ComponentModel.DataAnnotations;

namespace ControlePecasWeb_v0.Models
{
    public class Peca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string PartNumber { get; set; }

        [StringLength(15)]
        public string Seg { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        [StringLength(30)]
        public string Medida { get; set; }
    }
}
