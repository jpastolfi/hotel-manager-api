using Microsoft.EntityFrameworkCore;
using HotelManager.Models;

namespace HotelManager.Repository;
public class HotelManagerContext : DbContext, IHotelManagerContext
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    public HotelManagerContext(DbContextOptions<HotelManagerContext> options) : base(options)
    {
    }
    public HotelManagerContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=HotelManager;User=SA;Password=HotelManager12!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }

}