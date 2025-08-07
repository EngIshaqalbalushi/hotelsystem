using HotelSystem.Models;
using HotelSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
    public class ReviewService: IReviewService
    {

        private readonly IReviewRepository _repo;

        public ReviewService(IReviewRepository repo)
        {
            _repo = repo;
        }

        public void AddReview(Review review)
        {
            if (review.Rating < 1 || review.Rating > 5)
            {
                Console.WriteLine("Invalid rating. Must be between 1 and 5.");
                return;
            }

            _repo.Add(review);
            Console.WriteLine("Review added.");
        }

        public List<Review> GetReviewsByRoom(int roomNumber) =>
            _repo.GetReviewsForRoom(roomNumber);

        public List<Review> GetReviewsByGuest(string guestName) =>
            _repo.GetReviewsByGuest(guestName);

        public void UpdateReview(Review review)
        {
            _repo.Update(review);
            Console.WriteLine("Review updated.");
        }

        public void DeleteReview(int reviewId)
        {
            _repo.Delete(reviewId);
            Console.WriteLine("Review deleted.");
        }

    }
}
