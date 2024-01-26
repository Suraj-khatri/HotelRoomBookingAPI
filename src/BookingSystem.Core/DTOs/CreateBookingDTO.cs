using Abp.Application.Services.Dto;
using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DTOs
{
    public class CreateBookingDTO : EntityDto<Guid>
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}
        /*public string CustomerName { get; set; }
        public string CitizenshipNo { get; set; }*/
        public CreateCustomerDTO CreateCustomer { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
