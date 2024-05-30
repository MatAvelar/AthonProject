using ControlePecasWeb_v0.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlePecasWeb_v0.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> Tb_User { get; set; }
        public DbSet<Pneu> Tb_Pneu { get; set; }
        public DbSet<Peca> Tb_Peca { get; set;}
        public DbSet<Oficina> Tb_Oficina { get; set; }
        public DbSet<Equip> Tb_Equip { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<Oficina>()
                .HasOne(o => o.Peca)
                .WithMany()
                .HasForeignKey(o => o.PecaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Oficina>()
                .HasOne(o => o.Pneu)
                .WithMany()
                .HasForeignKey(o => o.PneuId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
