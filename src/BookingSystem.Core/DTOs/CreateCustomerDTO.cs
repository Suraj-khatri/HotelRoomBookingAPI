using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DTOs
{
    public class CreateCustomerDTO : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CitizenshipNo { get; set; }
        public string Email { get; set; }
    }
}
