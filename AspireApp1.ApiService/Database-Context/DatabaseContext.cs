using AspireApp1.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.ApiService.Database_Context;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    // Get all classes
    public DbSet<Usuario> Users { get; set; }
    public DbSet<Solicitante> Solicitantes { get; set; }
    public DbSet<Pago> Pagos { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    // Initial configuration in database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Declare data list
        List<Solicitante> solicitantesInit = new List<Solicitante>();
        // Initial data
        solicitantesInit.Add(new Solicitante
        { 
            Id_Solicitante = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56a"), 
            Nombre_Solicitante = "Juan Pérez", 
            Fecha_Nacimiento_Solicitante = new DateTime(1995, 6, 15) 
        });
        solicitantesInit.Add(new Solicitante
        { 
            Id_Solicitante = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Nombre_Solicitante = "María López", 
            Fecha_Nacimiento_Solicitante = new DateTime(1998, 2, 20) 
        });
        solicitantesInit.Add(new Solicitante
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
        pagosInit.Add(new Pago
        { 
            Id_Pago = Guid.Parse("102c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Monto_Pago = 1800.00, 
            Cuenta_Pago = "1234567890", 
            Sucursal_Pago = "9865", 
            Referencia_Pago = "REF12345", 
            Banco_Pago = Pago.Banco.CitiBanamex, 
            Concepto_Pago = "Inscripción", 
            Fecha_Limite_Pago = DateTime.Now.AddDays(30), 
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56a") 
        });
        pagosInit.Add(new Pago
        { 
            Id_Pago = Guid.Parse("202c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Monto_Pago = 2000.00, 
            Cuenta_Pago = "0987654321", 
            Sucursal_Pago = "9865", 
            Referencia_Pago = "REF67890", 
            Banco_Pago = Pago.Banco.BBVA, 
            Concepto_Pago = "Colegiatura", 
            Fecha_Limite_Pago = DateTime.Now.AddDays(15), 
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56b") 
        });
        pagosInit.Add(new Pago
        { 
            Id_Pago = Guid.Parse("302c2777-24a5-43ba-b05e-5ffe9a33b56b"), 
            Monto_Pago = 1700.00, 
            Cuenta_Pago = "1122334455", 
            Sucursal_Pago = "9865", 
            Referencia_Pago = "REF11223", 
            Banco_Pago = Pago.Banco.CitiBanamex, 
            Concepto_Pago = "Materiales", 
            Fecha_Limite_Pago = DateTime.Now.AddDays(45), 
            SolicitanteId = Guid.Parse("402c2777-24a5-43ba-b05e-5ffe9a33b56c") 
        });
        pagosInit.Add(new Pago
        {
            Id_Pago = Guid.Parse("102c2777-24a5-43ba-b05e-5ffe9a33b56d"),
            Monto_Pago = 1900.00,
            Cuenta_Pago = "1234567890",
            Sucursal_Pago = "9865",
            Referencia_Pago = "REF12345",
            Banco_Pago = Pago.Banco.BBVA,
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
        
        // Data user
        List<Usuario> usuariosInit = new List<Usuario>();
        usuariosInit.Add(new Usuario
        {
            Id_Usuario = Guid.Parse("702c2777-24a5-43ba-b05e-5ffe9a33b56a"),
            Nombre_Usuario = "Zein",
            Apellido_Paterno_Usuario = "García",
            Apellido_Materno_Usuario = "Hernández",
            FechaNacimiento_Usuario = new DateTime(1990, 5, 12),
            Contrasena_Usuario = "1234"
        });
        
        usuariosInit.Add(new Usuario
        {
            Id_Usuario = Guid.Parse("702c2777-24a5-43ba-b05e-5ffe9a33b56b"),
            Nombre_Usuario = "Ana",
            Apellido_Paterno_Usuario = "Martínez",
            Apellido_Materno_Usuario = "López",
            FechaNacimiento_Usuario = new DateTime(1992, 8, 23),
            Contrasena_Usuario = "securepassword"
        });
        
        usuariosInit.Add(new Usuario
        {
            Id_Usuario = Guid.Parse("702c2777-24a5-43ba-b05e-5ffe9a33b56c"),
            Nombre_Usuario = "Pedro",
            Apellido_Paterno_Usuario = "Sánchez",
            Apellido_Materno_Usuario = "Ramírez",
            FechaNacimiento_Usuario = new DateTime(1988, 11, 5),
            Contrasena_Usuario = "pass456"
        });
        
        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario.ToTable("Usuario");
            usuario.HasKey(p => p.Id_Usuario);
            usuario.Property(p => p.Nombre_Usuario).IsRequired().HasMaxLength(200);
            usuario.Property(p => p.Apellido_Paterno_Usuario);
            usuario.Property(p => p.Apellido_Materno_Usuario);
            usuario.Property(p => p.FechaNacimiento_Usuario).IsRequired();
            usuario.Property(p => p.Contrasena_Usuario).IsRequired().HasMaxLength(200);
            usuario.HasData(usuariosInit);
        });
        
        List<Alumno> alumnosInit = new List<Alumno>();
        alumnosInit.Add(new Alumno
        {
            Id_Alumno = Guid.Parse("802c2777-24a5-43ba-b05e-5ffe9a33b56a"),
            Nombre_Alumno = "Miguel",
            Apellido_Paterno_Alumno = "Torres",
            Apellido_Materno_Alumno = "Vega",
            Fecha_Nacimiento_Alumno = new DateTime(2000, 3, 14),
            Sexo_Alumno = Alumno.Sexo.Masculino,
            Carrera_Alumno = "Administración de empresas"
        });
        
        alumnosInit.Add(new Alumno
        {
            Id_Alumno = Guid.Parse("802c2777-24a5-43ba-b05e-5ffe9a33b56b"),
            Nombre_Alumno = "Sofía",
            Apellido_Paterno_Alumno = "González",
            Apellido_Materno_Alumno = "Díaz",
            Fecha_Nacimiento_Alumno = new DateTime(2001, 7, 19),
            Sexo_Alumno = Alumno.Sexo.Femenino,
            Carrera_Alumno = "Gastronomía"
        });
        
        alumnosInit.Add(new Alumno
        {
            Id_Alumno = Guid.Parse("802c2777-24a5-43ba-b05e-5ffe9a33b56c"),
            Nombre_Alumno = "Diego",
            Apellido_Paterno_Alumno = "Reyes",
            Apellido_Materno_Alumno = "Mendoza",
            Fecha_Nacimiento_Alumno = new DateTime(1999, 12, 2),
            Sexo_Alumno = Alumno.Sexo.Masculino,
            Carrera_Alumno = "Derecho"
        });
        
        modelBuilder.Entity<Alumno>(alumno =>
        {
            alumno.ToTable("Alumno");
            alumno.HasKey(p => p.Id_Alumno);
            alumno.Property(p => p.Nombre_Alumno).IsRequired().HasMaxLength(200);
            alumno.Property(p => p.Apellido_Paterno_Alumno);
            alumno.Property(p => p.Apellido_Materno_Alumno);
            alumno.Property(p => p.Fecha_Nacimiento_Alumno);
            alumno.Property(p => p.Sexo_Alumno).IsRequired();
            alumno.Property(p => p.Carrera_Alumno).IsRequired();
            alumno.Property(p => p.Curp_Alumno).IsRequired(false);
            alumno.Property(p => p.Bachillerato_Alumno).IsRequired(false);
            alumno.Property(p => p.Estado_Alumno).IsRequired(false);
            alumno.HasData(alumnosInit);
        });
    }
}