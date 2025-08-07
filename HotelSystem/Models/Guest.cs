using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
   public class Guest
    {
        [Key]
        public string GuestName { get; set; } = string.Empty;

        public ICollection<Reservation>? Reservations { get; set; }


    }
}
