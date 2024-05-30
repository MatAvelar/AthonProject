using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ControlePecasWeb_v0.Models
{
    public class Oficina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Equip")]
        public int EquipId { get; set; }
        public Equip Equip { get; set; }

        [ForeignKey("Pneu")]
        public int PneuId { get; set; }
        public Pneu Pneu { get; set; }

        [ForeignKey("Peca")]
        public int PecaId { get; set; }
        public Peca Peca { get; set; }
    }

}
