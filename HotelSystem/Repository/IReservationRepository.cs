using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
    public interface IReservationRepository : IRepository<Reservation>
    {

        Reservation? GetById(int id);

    }
}
