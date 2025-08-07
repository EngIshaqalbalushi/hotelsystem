using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
  public  class ReviewRepository: IReviewRepository
    {

        private readonly HotelContext _context;

        public ReviewRepository(HotelContext context)
        {
            _context = context;
        }

        public void Add(Review entity)
        {
            _context.Reviews.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Review entity)
        {
            var existing = GetById(entity.ReviewId);
            if (existing == null) return;

            existing.Rating = entity.Rating;
            existing.Comment = entity.Comment;
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var review = GetById(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }

        public Review? GetById(object id) =>
            _context.Reviews.FirstOrDefault(r => r.ReviewId == (int)id);

        public List<Review> GetAll() =>
            _context.Reviews.ToList();

        public List<Review> GetReviewsForRoom(int roomNumber) =>
            _context.Reviews.Where(r => r.RoomNumber == roomNumber).ToList();

        public List<Review> GetReviewsByGuest(string guestName) =>
            _context.Reviews.Where(r => r.GuestName == guestName).ToList();
    }

}

