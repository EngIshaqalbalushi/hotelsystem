using HotelSystem.Models;

using System.Collections.Generic;
using System.Linq;

namespace HotelSystem.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelContext _context;

        public GuestRepository(HotelContext context)
        {
            _context = context;
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
                // Update fields here (if needed)
                // Example: existing.Email = guest.Email;
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

        // This is the custom override for string name
        public Guest? GetById(string name)
        {
            return _context.Guests.FirstOrDefault(g => g.GuestName == name);
        }

        public List<Guest> GetAll()
        {
            return _context.Guests.ToList();
        }
    }
}
