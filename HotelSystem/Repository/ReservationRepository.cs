using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
   public class ReservationRepository: IReservationRepository
    {

        private readonly HotelContext _context;

        public ReservationRepository(HotelContext context)
        {
            _context = context;
        }

        public void Add(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            var existing = _context.Reservations.Find(entity.ReservationID);
            if (existing != null)
            {
                existing.Nights = entity.Nights;
                existing.TotalCost = entity.TotalCost;
                _context.SaveChanges();
            }
        }

        public void Delete(object id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public Reservation? GetById(object id)
        {
            return _context.Reservations.Find(id);
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }
        public Reservation? GetById(int id)
        {
            return _context.Reservations.FirstOrDefault(r => r.ReservationID == id);
        }


    }
}
