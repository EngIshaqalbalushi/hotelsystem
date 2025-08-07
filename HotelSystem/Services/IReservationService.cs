using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
  public  interface IReservationService
    {

        void AddReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation? GetById(int id);
        void UpdateReservation(Reservation reservation);
        void CancelReservation(int id);

    }
}
