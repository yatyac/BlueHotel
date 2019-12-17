using DomaineModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class BlueContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public BlueContext()
            : base()
        {
        }
        public BlueContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=BlueDb; Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relation Hotel to Rooms : Many to One
            modelBuilder.Entity<Hotel>().HasMany(h => h.Rooms).WithOne(r => r.Hotel);
            // Relation Hotel to Address : One to One
            modelBuilder.Entity<Hotel>().HasOne(h => h.Address);
            // Relation Customer to Bookings : Many to One
            modelBuilder.Entity<Customer>().HasMany(c => c.Bookings).WithOne(b => b.Customer);
            // Relation Customer to Address : One to One
            modelBuilder.Entity<Customer>().HasOne(c => c.Address);

            // Many to Many
            modelBuilder.Entity<BookingRoom>().HasKey(br => new { br.BookingId, br.RoomId });// Déclarer les clés primaires de Booking et Room dans la table de liaison
            modelBuilder.Entity<Room>().HasMany(r => r.BookingRooms).WithOne(br => br.Room);
            modelBuilder.Entity<Booking>().HasMany(b => b.BookingRooms).WithOne(br => br.Booking);

            base.OnModelCreating(modelBuilder);
        }
    }
}
