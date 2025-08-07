using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Services
{
    public interface IReviewService
    {

        void AddReview(Review review);
        List<Review> GetReviewsByRoom(int roomNumber);
        List<Review> GetReviewsByGuest(string guestName);
        void UpdateReview(Review review);
        void DeleteReview(int reviewId);


    }
}
