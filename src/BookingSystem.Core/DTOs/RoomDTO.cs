using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DTOs
{
    public class RoomDTO : EntityDto<Guid>
    {
        public string RoomNo { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
