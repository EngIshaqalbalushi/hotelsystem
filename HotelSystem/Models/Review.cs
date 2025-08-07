using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Models
{
    public class Review
    {


        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Guest")]
        public string GuestName { get; set; } = string.Empty;

        [ForeignKey("Room")]
        public int RoomNumber { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Guest? Guest { get; set; }
        public Room? Room { get; set; }



    }
}
