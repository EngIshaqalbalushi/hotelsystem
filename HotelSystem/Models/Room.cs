using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
  public  class Room
    {
    
        
            [Key]
            public int RoomNumber { get; set; }

            [Range(100, double.MaxValue)]
            public double DailyRate { get; set; }

            public bool IsReserved { get; set; }

            public ICollection<Reservation>? Reservations { get; set; }

        }
    }

