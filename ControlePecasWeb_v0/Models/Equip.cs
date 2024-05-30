using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ControlePecasWeb_v0.Models
{
    public class Equip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(15)]
        public string Marca { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        public float? Horimetro { get; set; }

        [ForeignKey("Pneu")]
        public int PneuId { get; set; }
        public Pneu Pneu { get; set; }

        [ForeignKey("Peca")]
        public int PecaId { get; set; }
        public Peca Peca { get; set; }
    }

}
