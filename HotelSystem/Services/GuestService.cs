using HotelSystem.Models;
using HotelSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
    public class GuestService : IGuestService
    {



        private readonly HotelContext _context;

        public GuestService(HotelContext context)
        {
            _context = context;
        }

        public void AddGuest(Guest guest)
        {
            if (_context.Guests.Any(g => g.GuestName == guest.GuestName))
            {
                Console.WriteLine("Guest already exists.");
                return;
            }

            _context.Guests.Add(guest);
            _context.SaveChanges();
            Console.WriteLine("Guest added.");
        }

        public List<Guest> GetAllGuests() => _context.Guests.ToList();

        public Guest? GetGuestByName(string name) =>
            _context.Guests.FirstOrDefault(g => g.GuestName == name);

        public void UpdateGuest(Guest guest)
        {
            var existing = GetGuestByName(guest.GuestName);
            if (existing == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            // Add more properties if needed
            _context.SaveChanges();
            Console.WriteLine("Guest updated.");
        }

        public void DeleteGuest(string name)
        {
            var guest = GetGuestByName(name);
            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            _context.Guests.Remove(guest);
            _context.SaveChanges();
            Console.WriteLine("Guest deleted.");
        }



        private readonly IGuestRepository _repo;

        public GuestService(IGuestRepository repo)
        {
            _repo = repo;
        }


        public void Add(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
        }

        public void Update(Guest guest)
        {
            var existing = _context.Guests.Find(guest.GuestName);
            if (existing != null)
            {
                // Update fields here if needed
                _context.SaveChanges();
            }
        }

        public void Delete(object id)
        {
            var guest = _context.Guests.Find(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
            }
        }

        public Guest? GetById(object id)
        {
            return _context.Guests.Find(id);
        }

        public List<Guest> GetAll()
        {
            return _context.Guests.ToList();
        }

    }
}
