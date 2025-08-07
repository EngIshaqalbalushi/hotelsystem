using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
    public class RoomRepository: IRoomRepository
    {


        private readonly HotelContext _context;

        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public void Add(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Room entity)
        {
            var existing = GetByRoomNumber(entity.RoomNumber);
            if (existing == null) return;

            existing.DailyRate = entity.DailyRate;
            existing.IsReserved = entity.IsReserved;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var room = GetByRoomNumber((int)id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public Room? GetById(object id) => GetByRoomNumber((int)id);

        public Room? GetByRoomNumber(int roomNumber) =>
            _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

        public List<Room> GetAll() => _context.Rooms.ToList();
    }





}

