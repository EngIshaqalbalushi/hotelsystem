using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
   public interface IRoomRepository : IRepository<Room>
    {
      
        Room? GetByRoomNumber(int roomNumber);




    }
}
