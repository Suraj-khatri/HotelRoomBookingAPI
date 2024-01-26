using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DTOs
{
    public class GetAllBookingsDTO : EntityDto<Guid>
    {
        public string CustomerName { get; set; }
        public List<string> RoomName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}
        public decimal TotalAmount { get; set; }
    }
}
