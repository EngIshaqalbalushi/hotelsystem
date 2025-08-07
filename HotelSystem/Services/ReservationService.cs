using HotelSystem.Models;
using HotelSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
    public class ReservationService: IReservationService
    {

        private readonly HotelContext _context;

        public ReservationService(HotelContext context)
        {
            _context = context;
        }

        public void AddReservation(Reservation reservation)
        {
            var room = _context.Rooms.Find(reservation.RoomNumber);
            if (room == null || room.IsReserved)
            {
                Console.WriteLine("Room invalid or already reserved.");
                return;
            }

            if (_context.Guests.Find(reservation.GuestName) == null)
            {
                _context.Guests.Add(new Guest { GuestName = reservation.GuestName });
            }

            room.IsReserved = true;
            reservation.TotalCost = room.DailyRate * reservation.Nights;
            reservation.BookingDate = DateTime.Now;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            Console.WriteLine("Reservation made.");
        }

        public List<Reservation> GetAllReservations() =>
            _context.Reservations.ToList();

        public Reservation? GetById(int id) =>
            _context.Reservations.FirstOrDefault(r => r.ReservationID == id);

        public void UpdateReservation(Reservation reservation)
        {
            var existing = GetById(reservation.ReservationID);
            if (existing == null)
            {
                Console.WriteLine("Reservation not found.");
                return;
            }

            existing.Nights = reservation.Nights;
            existing.TotalCost = reservation.Nights * _context.Rooms.Find(reservation.RoomNumber)?.DailyRate ?? 0;
            _context.SaveChanges();
            Console.WriteLine("Reservation updated.");
        }

        public void CancelReservation(int id)
        {
            var reservation = GetById(id);
            if (reservation == null)
            {
                Console.WriteLine("Reservation not found.");
                return;
            }

            var room = _context.Rooms.Find(reservation.RoomNumber);
            if (room != null) room.IsReserved = false;

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            Console.WriteLine("Reservation cancelled.");
        }

        private readonly IReservationRepository _repo;

        public ReservationService(IReservationRepository repo) // ✅ CORRECT
        {
            _repo = repo;
        }

    }
}
