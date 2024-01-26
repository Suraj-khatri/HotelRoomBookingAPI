using Abp.Domain.Repositories;
using Abp.Threading.Extensions;
using Abp.UI;
using BookingSystem.DTOs;
using BookingSystem.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.AppService
{
    public class HotelRoomBookingAppService : BookingSystemAppServiceBase
    {
        private readonly IRepository<Customer,Guid> _customerRepository;
        private readonly IRepository<Room,Guid> _roomRepository;
        private readonly IRepository<Booking,Guid> _bookingRepository;
        private readonly IRepository<RoomBooking, Guid> _roomBookingRepository;

        public HotelRoomBookingAppService(IRepository<Customer, Guid> customerRepository, 
            IRepository<Room, Guid> roomRepository, 
            IRepository<Booking, Guid> bookingRepository,
            IRepository<RoomBooking,Guid> roomBookingRepository)
        {
            _customerRepository = customerRepository;
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _roomBookingRepository = roomBookingRepository;
        }

        public async Task CreateBooking(CreateBookingDTO input)
        {

            var customer = new Customer
            {
                Name = input.CreateCustomer.Name,
                CitizenShipNo = input.CreateCustomer.CitizenshipNo,
                Address = input.CreateCustomer.Address,
                Email = input.CreateCustomer.Email,

            };
            var customerId = await _customerRepository.InsertAndGetIdAsync(customer);
            var TotalAmount = (input.CheckOutDate - input.CheckInDate).Days * input.Rooms.Sum(x => x.Price);

            if (input.Rooms.Count>=3)
            {
                TotalAmount = TotalAmount - (0.05m * TotalAmount);

            }


            var booking = new Booking
            {
                CustomerId = customerId,
                CheckInDate = input.CheckInDate,
                CheckOutDate = input.CheckOutDate,
                TotalPrice = TotalAmount
             };
            var bookingId = await _bookingRepository.InsertAndGetIdAsync(booking);


            foreach(var room in input.Rooms)
            {
                room.IsAvailable = false;
                await _roomRepository.UpdateAsync(room);
                var roomBooking = new RoomBooking
                {
                    BookingId = bookingId,
                    RoomId = room.Id,
                };
                await _roomBookingRepository.InsertAsync(roomBooking);
            }
            
        }

        public async Task DeleteBooking(Guid id)
        {
            var booking = await _bookingRepository.GetAll().AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id ==id);
            if(booking == null)
            {
                throw new UserFriendlyException("Booking not found");
            }
            
            var allbookings = await _roomBookingRepository.GetAll().AsNoTracking()
                .Where(x => x.BookingId == id).ToListAsync();
            foreach(var bookings in allbookings)
            {
                var room = await _roomRepository.GetAsync(bookings.RoomId);
                room.IsAvailable = true;
                await _roomBookingRepository.DeleteAsync(bookings);
            }
            await _bookingRepository.DeleteAsync(booking);
        }

        public async Task<List<GetAllBookingsDTO>> GetAllBookings()
        {
            var roomNames = await _roomBookingRepository.GetAllIncluding(rb => rb.RoomFK)
                .Select(rb => rb.RoomFK.RoomNo)
                .ToListAsync();
            var roomList = new List<string>();
            foreach (var names in roomNames)
            {
                roomList.Add(names);
            }

            var bookingDetails = await _roomBookingRepository.GetAllIncluding(rb => rb.BookingFK.CustomerFK, rb => rb.RoomFK)
            .Select(rb => new GetAllBookingsDTO
            {
                Id = rb.BookingId,
                RoomName = roomList,
                CustomerName = rb.BookingFK.CustomerFK.Name,
                CheckInDate = rb.BookingFK.CheckInDate,
                CheckOutDate = rb.BookingFK.CheckOutDate,
                TotalAmount = rb.BookingFK.TotalPrice
            }).Distinct()
            .ToListAsync();

            
            

            return bookingDetails;
        }

        public async Task<List<GetAllBookingsDTO>> GetAllBooking()
        {
            var Result = new List<GetAllBookingsDTO>();
            var allBookings = await _roomBookingRepository.GetAll().AsNoTracking()
                .ToListAsync();

            var grouppedBookings = allBookings.GroupBy(x => x.BookingId)
                .Select(x => new
                {
                    key = x.Key,
                    allBooking = x.OrderBy(x => x.BookingId)
                });

            foreach(var group in  grouppedBookings)
            {
                
                
                var roomNames = new List<string>();
                foreach (var book in group.allBooking)
                {
                    var roomName = _roomRepository.GetAll().AsNoTracking().Where(x => x.Id == book.RoomId).Select(x => x.RoomNo).FirstOrDefault();
                    roomNames.Add(roomName);
                }
                var booking = await _bookingRepository.GetAll().AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == group.key);
                var res = new GetAllBookingsDTO
                {
                    Id = booking.Id,
                    CustomerName = _customerRepository.GetAll().AsNoTracking().Where(x => x.Id == booking.CustomerId).Select(x => x.Name).FirstOrDefault(),
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    TotalAmount = booking.TotalPrice,
                    RoomName = roomNames
                    
                };
                Result.Add(res);
            }
                return Result;
        }
        

    }
}
