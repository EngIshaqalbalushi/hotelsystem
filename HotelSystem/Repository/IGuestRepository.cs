using HotelSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HotelSystem.Repository
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Guest? GetById(string name); // or however you're defining it
    }
}
