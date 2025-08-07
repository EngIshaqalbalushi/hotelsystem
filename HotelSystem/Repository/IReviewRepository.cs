using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Repository
{
    public interface IReviewRepository:IRepository<Review>
    {

        List<Review> GetReviewsForRoom(int roomNumber);
        List<Review> GetReviewsByGuest(string guestName);

    }
}
