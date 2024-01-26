using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CitizenShipNo { get; set; }
        public string Email { get; set; }
    }
}
