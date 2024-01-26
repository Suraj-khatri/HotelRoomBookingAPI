using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class Booking : Entity<Guid>
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}
        public decimal TotalPrice { get; set; }

        public virtual Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer CustomerFK { get; set; }
        
    }
}
