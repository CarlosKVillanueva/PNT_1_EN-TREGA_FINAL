using Microsoft.EntityFrameworkCore;
using RESERVA_RESTAURANT_PNT1.Models;

namespace RESERVA_RESTAURANT_PNT1.Data;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ClientePlato>()
            .HasKey(cp => new { cp.ClienteId, cp.PlatoId });

        modelBuilder.Entity<ClientePlato>()
            .HasOne(cp => cp.Cliente)
            .WithMany(cliente => cliente.PlatosConsumidos)
            .HasForeignKey(cp => cp.ClienteId);

        modelBuilder.Entity<ClientePlato>()
            .HasOne(cp => cp.Plato)
            .WithMany(plato => plato.FueConsumido)
            .HasForeignKey(cp => cp.PlatoId);
    }

    public DbSet<Persona> Personas { get; set; } 
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    
    public DbSet<Plato> Platos { get; set; }

    public DbSet<Bebida> Bebidas { get; set; }

    public DbSet<ClientePlato> PlatosClientes { get; set; }

}