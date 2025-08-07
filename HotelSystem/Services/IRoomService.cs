using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelSystem.Models;
namespace HotelSystem.Services
{
  public  interface IRoomService
    {

        void AddRoom(Room room);
        List<Room> GetAllRooms();
        Room? GetRoomByNumber(int roomNumber);
        void UpdateRoom(Room room);
        void DeleteRoom(int roomNumber);

    }
}
