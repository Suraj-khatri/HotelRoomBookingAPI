using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class RoomBooking : Entity<Guid>
    {
        public virtual Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room RoomFK { get; set; }
        public virtual Guid BookingId { get; set; }
        [ForeignKey("BookingId")]
        public Booking BookingFK { get; set; }
    }
}
