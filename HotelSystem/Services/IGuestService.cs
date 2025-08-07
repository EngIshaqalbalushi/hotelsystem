using HotelSystem.Models;
using HotelSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
  public  interface IGuestService : IRepository<Guest>
    {
        void AddGuest(Guest guest);
        List<Guest> GetAllGuests();
   
    }
}
