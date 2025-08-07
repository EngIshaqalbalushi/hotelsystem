using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
   public class Reservation
    {


        [Key]
        public int ReservationID { get; set; }

        [ForeignKey("Room")]
        public int RoomNumber { get; set; }

        [ForeignKey("Guest")]
        public string GuestName { get; set; } = string.Empty;

        public int Nights { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        public double TotalCost { get; set; }

        public Room? Room { get; set; }
        public Guest? Guest { get; set; }




    }
}
