using Microsoft.EntityFrameworkCore;
using HotelManager.Models;

namespace HotelManager.Repository
{
    public interface IHotelManagerContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public int SaveChanges();
    }
}
