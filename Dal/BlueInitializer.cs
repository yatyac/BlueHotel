using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomaineModel;
using DomaineModel.Entities;

namespace Dal
{
    public  static class BlueInitializer
    {
        public static void Initialize(this BlueContext context, bool dropAlways = false)
        {
            // To drop database or not
            if (dropAlways)
                context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // If db has been already seeded
            if (context.Hotels.Any())
                return;
            var addresses = new List<Address>()
            {
                //hotel's address
                new Address()
                {
                    Street = "15 rue soleysel",
                    Zipcode = "42000",
                    City = "Saint-Etienne",
                    Country = "France",
                    Email = "email@email.com",
                    Phone = "+3325652365",
                    Latitude = 45,
                    Longitude = 75
                },
                 new Address()
                {
                    Street = "11 rue Larue",
                    Zipcode = "43000",
                    City = "Saint-Etienne",
                    Country = "France",
                    Email = "email@email.com",
                    Phone = "+3325652365",
                    Latitude = 32,
                    Longitude = 25
                },
                  new Address()
                {
                    Street = "47 rue Poular",
                    Zipcode = "75000",
                    City = "Paris",
                    Country = "France",
                    Email = "email@email.com",
                    Phone = "+3325652365",
                    Latitude = 45,
                    Longitude = 75
                },

                  // Customer's address
                   new Address()
                {
                    Street = "65 rue la couronne",
                    Zipcode = "69000",
                    City = "Lyon",
                    Country = "France",
                    Email = "email@email.com",
                    Phone = "+3325652365"
                },
                    new Address()
                {
                    Street = "23 rue arthur",
                    Zipcode = "69000",
                    City = "Lyon",
                    Country = "France",
                    Email = "email@email.com",
                    Phone = "+3325652365"
                },
                     new Address()
                {
                    Street = "10 rue trang",
                    Zipcode = "35000",
                    City = "Rennes",
                    Country = "France",
                    Email = "email@email.com",
                    Phone = "+3325652365"
                },
            };
            var rooms = new List<Room>()
            {
                new Room()
                {
                    Name = "Roi Soleil",
                    Floor = 56,
                    Category = "Nuptiale"
                },
                new Room()
                {
                    Name = "La belle au bois dormant",
                    Floor = 98,
                    Category = "Joyful"
                },
                new Room()
                {
                    Name = "Supernatural",
                    Floor = 86,
                    Category = "Horror"
                },
                new Room()
                {
                    Name = "Le roi Arthur",
                    Floor = 17,
                    Category = "History"
                },
                new Room()
                {
                    Name = "Chez Kader",
                    Floor = 42,
                    Category = "Sweet"
                },
                new Room()
                {
                    Name = "Dolly",
                    Floor = 78,
                    Category = "Juicy"
                },
            };
            var hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Name = "Double Tree",
                    Star = 5,
                    Address = addresses[0]
                },
                new Hotel()
                {
                    Name = "Hilton",
                    Star = 5,
                    Address = addresses[1]
                },
                new Hotel()
                {
                    Name = "Fousco",
                    Star = 3,
                    Address = addresses[2]
                },
            };
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    FullName = "Yacouba Yattara",
                    DateOfBirth =DateTime.Now,
                    Address = addresses[3],
                },
                new Customer()
                {
                    FullName = "trang Luu",
                    DateOfBirth =DateTime.Now.AddDays(5),
                    Address = addresses[4],
                },
                new Customer()
                {
                    FullName = "Alex jenesaispas",
                    DateOfBirth =DateTime.Now.AddDays(10),
                    Address = addresses[5],
                },
            };
            var bookings = new List<Booking>()
            {
                new Booking()
                {
                    Created = DateTime.Now.AddDays(10),
                    CheckIn = DateTime.Now.AddDays(9),
                    CheckOut = DateTime.Now.AddDays(8),
                    Price = 190,
                    IsPaid = true,
                    Customer = customers[0]
                },
                new Booking()
                {
                    Created = DateTime.Now.AddDays(20),
                    CheckIn = DateTime.Now.AddDays(19),
                    CheckOut = DateTime.Now.AddDays(18),
                    Price = 200,
                    IsPaid = true,
                    Customer = customers[1]
                },
                new Booking()
                {
                    Created = DateTime.Now.AddDays(15),
                    CheckIn = DateTime.Now.AddDays(11),
                    CheckOut = DateTime.Now.AddDays(10),
                    Price = 300,
                    IsPaid = true,
                    Customer = customers[2]
                },
            };
            var bookingRooms = new List<BookingRoom>()
            {
                new BookingRoom()
                {
                    Booking = bookings[0],
                    Room = rooms[0],
                },
                new BookingRoom()
                {
                    Booking = bookings[1],
                    Room = rooms[3],
                },
                new BookingRoom()
                {
                    Booking = bookings[2],
                    Room = rooms[5],
                },
            };

            context.Addresses.AddRange(addresses);
            context.Rooms.AddRange(rooms);
            context.Hotels.AddRange(hotels);
            context.Customers.AddRange(customers);
            context.BookingRooms.AddRange(bookingRooms);
            context.SaveChanges();

        }
    }
}
