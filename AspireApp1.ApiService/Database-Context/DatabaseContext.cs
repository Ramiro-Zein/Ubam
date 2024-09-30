using AspireApp1.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.AppDbContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Solicitante> Solicitante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Solicitante>(solicitante =>
            {
                solicitante.ToTable("Solicitante");
                solicitante.HasKey(p => p.Id_Solicitante);
                solicitante.Property(p => p.Nombre_Solicitante).IsRequired().HasMaxLength(255);
                solicitante.Property(p => p.Fecha_Nacimiento_Solicitante).IsRequired();
            });

            modelBuilder.Entity<Pago>(pago =>
            {
                pago.ToTable("Pago");
                pago.HasKey(p => p.Id_Pago);
                pago.HasOne(p => p.Solicitante)
                    .WithMany(s => s.Pagos)
                    .HasForeignKey(p => p.Id_Solicitante)
                    .OnDelete(DeleteBehavior.Cascade);
                pago.Property(p => p.Monto_Pago).IsRequired().HasMaxLength(10);
                pago.Property(p => p.Cuenta_Pago).IsRequired().HasMaxLength(50);
                pago.Property(p => p.Sucursal_Pago).IsRequired().HasMaxLength(50);
                pago.Property(p => p.Referencia_Pago).IsRequired().HasMaxLength(50);
                pago.Property(p => p.Banco_Pago).IsRequired().HasMaxLength(50);
                pago.Property(p => p.Concepto_Pago).IsRequired().HasMaxLength(50);
                pago.Property(p => p.Fecha_Limite_Pago).IsRequired();
            });

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");
                user.HasKey(p => p.Id);
                user.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
            });
        }


    }
}
