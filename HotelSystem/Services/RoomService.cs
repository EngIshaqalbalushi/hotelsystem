using HotelSystem.Models;
using HotelSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
    public class RoomService : IRoomService
    {

        private readonly HotelContext _context;

        public RoomService(HotelContext context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            if (_context.Rooms.Any(r => r.RoomNumber == room.RoomNumber))
            {
                Console.WriteLine("Room already exists.");
                return;
            }

            _context.Rooms.Add(room);
            _context.SaveChanges();
            Console.WriteLine("Room added successfully.");
        }

        public List<Room> GetAllRooms() => _context.Rooms.ToList();

        public Room? GetRoomByNumber(int roomNumber) =>
            _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

        public void UpdateRoom(Room room)
        {
            var existing = GetRoomByNumber(room.RoomNumber);
            if (existing == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            existing.DailyRate = room.DailyRate;
            existing.IsReserved = room.IsReserved;
            _context.SaveChanges();
            Console.WriteLine("Room updated.");
        }

        public void DeleteRoom(int roomNumber)
        {
            var room = GetRoomByNumber(roomNumber);
            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();
            Console.WriteLine("Room deleted.");
        }

        public RoomService(IRoomRepository repo)
        {
            _repo = repo;
        }

     




     
    private readonly IRoomRepository _repo; //  Declare the field

   
    }
}
