using AspireApp1.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Database_Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    // Get all classes
    public DbSet<Usuario> Users { get; set; }
    public DbSet<Solicitante> Solicitantes { get; set; }
    public DbSet<Pago> Pagos { get; set; }

    // Initial configuration in database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Declare data list
        List<Solicitante> solicitantesInit = new List<Solicitante>();
        // Initial data
        solicitantesInit.Add(new Solicitante() 
        { 
            Id_Solicitante = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56a"), 
            Nombre_Solicitante = "Juan Pérez", 
            Fecha_Nacimiento_Solicitante = new DateTime(1995, 6, 15) 
        });
        solicitantesInit.Add(new Solicitante() 
        { 
            Id_Solicitante = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Nombre_Solicitante = "María López", 
            Fecha_Nacimiento_Solicitante = new DateTime(1998, 2, 20) 
        });
        solicitantesInit.Add(new Solicitante() 
        { 
            Id_Solicitante = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56c"), 
            Nombre_Solicitante = "Carlos Ramírez", 
            Fecha_Nacimiento_Solicitante = new DateTime(2000, 10, 5) 
        });
            
        modelBuilder.Entity<Solicitante>(solicitante =>
        {
            solicitante.ToTable("Solicitante"); // Table name
            solicitante.HasKey(p => p.Id_Solicitante);
            solicitante.HasMany(s => s.Pagos)
                .WithOne(p => p.Solicitante)
                .HasForeignKey(p => p.SolicitanteId)
                .OnDelete(DeleteBehavior.Cascade);
            solicitante.Property(p => p.Nombre_Solicitante).IsRequired().HasMaxLength(255);
            solicitante.Property(p => p.Fecha_Nacimiento_Solicitante).IsRequired();
            solicitante.HasData(solicitantesInit); // Add initial data
        });
            
        // Initial data
        List<Pago> pagosInit = new List<Pago>();
        pagosInit.Add(new Pago() 
        { 
            Id_Pago = Guid.Parse("102c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Monto_Pago = 1800.00, 
            Cuenta_Pago = "1234567890", 
            Sucursal_Pago = "9865", 
            Referencia_Pago = "REF12345", 
            Banco_Pago = "Citibanamex", 
            Concepto_Pago = "Inscripción", 
            Fecha_Limite_Pago = DateTime.Now.AddDays(30), 
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56a") 
        });
        pagosInit.Add(new Pago() 
        { 
            Id_Pago = Guid.Parse("202c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Monto_Pago = 2000.00, 
            Cuenta_Pago = "0987654321", 
            Sucursal_Pago = "9865", 
            Referencia_Pago = "REF67890", 
            Banco_Pago = "BBVA", 
            Concepto_Pago = "Colegiatura", 
            Fecha_Limite_Pago = DateTime.Now.AddDays(15), 
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56b") 
        });
        pagosInit.Add(new Pago() 
        { 
            Id_Pago = Guid.Parse("302c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Monto_Pago = 1700.00, 
            Cuenta_Pago = "1122334455", 
            Sucursal_Pago = "9865", 
            Referencia_Pago = "REF11223", 
            Banco_Pago = "BBVA", 
            Concepto_Pago = "Materiales", 
            Fecha_Limite_Pago = DateTime.Now.AddDays(45), 
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56c") 
        });
        pagosInit.Add(new Pago()
        {
            Id_Pago = Guid.Parse("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
            Monto_Pago = 1900.00,
            Cuenta_Pago = "1234567890",
            Sucursal_Pago = "9865",
            Referencia_Pago = "REF12345",
            Banco_Pago = "Citibanamex",
            Concepto_Pago = "Inscripción",
            Fecha_Limite_Pago = DateTime.Now.AddDays(30),
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56c")
        });

        modelBuilder.Entity<Pago>(pago =>
        {
            pago.ToTable("Pago");
            pago.HasKey(p => p.Id_Pago);
            pago.Property(p => p.Monto_Pago).IsRequired().HasColumnType("decimal(18,2)");
            pago.Property(p => p.Cuenta_Pago).IsRequired().HasMaxLength(50);
            pago.Property(p => p.Sucursal_Pago).IsRequired().HasMaxLength(50);
            pago.Property(p => p.Referencia_Pago).IsRequired().HasMaxLength(50);
            pago.Property(p => p.Banco_Pago).IsRequired().HasMaxLength(50);
            pago.Property(p => p.Concepto_Pago).IsRequired().HasMaxLength(50);
            pago.Property(p => p.Fecha_Limite_Pago).IsRequired();
            pago.HasData(pagosInit); // Add initial data
        });
        
        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario.ToTable("Usuario");
            usuario.HasKey(p => p.Id);
            usuario.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
        });
    }
}