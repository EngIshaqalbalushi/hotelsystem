using HotelSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
  public  class HotelContext:DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelRoomDB;Trusted_Connection=True;");

        }

        public DbSet<Review> Reviews => Set<Review>();

        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Guest> Guests => Set<Guest>();
        public DbSet<Reservation> Reservations => Set<Reservation>();





    }
}
