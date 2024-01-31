using Microsoft.EntityFrameworkCore;
using HotelManager.Models;
using HotelManager.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManager.Test;

public class ContextTest : DbContext, IHotelManagerContext
{
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Hotel> Hotels { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public ContextTest(DbContextOptions<ContextTest> options) : base(options)
    { }

}