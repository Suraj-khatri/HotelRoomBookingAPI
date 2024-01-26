using Abp.Domain.Repositories;
using Abp.UI;
using BookingSystem.DTOs;
using BookingSystem.Models;
using BookingSystem.Roles.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.AppService
{
    public class RoomAppService : BookingSystemAppServiceBase
    {
        private readonly IRepository<Room, Guid> _roomRepository;

        public RoomAppService(IRepository<Room, Guid> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<List<Room>> GetAllRooms()
        {
            var rooms = await _roomRepository.GetAll().AsNoTracking()
                .Select(x => new Room
                {
                    Id = x.Id,
                    RoomNo = x.RoomNo,
                    Capacity = x.Capacity,
                    IsAvailable = x.IsAvailable,
                    Price = x.Price,
                    RoomType = x.RoomType,
                }).ToListAsync();
            if (!rooms.Any())
            {
                throw new UserFriendlyException(404, "Rooms not found");
            }
            return rooms;
        }
        public async Task<Room> GetRoomById(Guid id)
        {
            var rooms = await _roomRepository.GetAll().AsNoTracking()
                .Where(x => x.Id == id)
               .Select(x => new Room
               {
                   Id = x.Id,
                   RoomNo = x.RoomNo,
                   Capacity = x.Capacity,
                   IsAvailable = x.IsAvailable,
                   Price = x.Price,
                   RoomType = x.RoomType,
               }).FirstOrDefaultAsync();
            if (rooms == null)
            {
                throw new UserFriendlyException(404, "Room Not Found with id " + id);
            }
            return rooms;
        }
        public async Task CreateOrUpdate(CreateUpdateRoomDTO input)
        {
            if (input.Id == null || input.Id == Guid.Empty)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }
        protected virtual async Task Create(CreateUpdateRoomDTO input)
        {
            var existRoom = await _roomRepository.GetAll().AsNoTracking().FirstOrDefaultAsync(x=>x.RoomNo == input.RoomNo);
            if(existRoom != null)
            {
                throw new UserFriendlyException("Cannot add", "Room with this Room Number already exists");
            }
            var newRoom = new Room
            {
                RoomNo = input.RoomNo,
                Capacity = input.Capacity,
                IsAvailable = input.IsAvailable,
                Price = input.Price,
                RoomType = input.RoomType
            };
            await _roomRepository.InsertAsync(newRoom);
        }
        protected virtual async Task Update(CreateUpdateRoomDTO input)
        {
            var room = await _roomRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (room == null)
                throw new UserFriendlyException(404, "Room not found");
            room.RoomNo = input.RoomNo;
            room.Capacity = input.Capacity;
            room.IsAvailable = input.IsAvailable;
            room.Price = input.Price;
            room.RoomType = input.RoomType;
            await _roomRepository.UpdateAsync(room);
        }

        public async Task DeleteRoom(Guid id)
        {
            var room = await _roomRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (room == null)
                throw new UserFriendlyException(404, "Room not found");

            await _roomRepository.DeleteAsync(room);
        }

        public async Task<List<Room>>GetAvailableRoomTypes(string roomType)
        {

           var allAvailableRooms = await _roomRepository.GetAll().AsNoTracking()
                .Where(x => x.RoomType == roomType && x.IsAvailable == true).ToListAsync(); 
                
            if(!allAvailableRooms.Any())
            {
                throw new UserFriendlyException("No Available Rooms");
            }
            return allAvailableRooms;
        }

        public async Task<List<AvailableRoomDTO>> GetAvailableRoom()
        {

            var allAvailableRooms = await _roomRepository.GetAll().AsNoTracking()
                 .Where(x =>x.IsAvailable == true)
                 .Select(x=> new AvailableRoomDTO
                 {
                     Id = x.Id,
                     RoomNo = x.RoomNo,
                     Capacity = x.Capacity,
                     Price = x.Price,
                     RoomType = x.RoomType,
                 }).ToListAsync();

            if (!allAvailableRooms.Any())
            {
                throw new UserFriendlyException("No Available Rooms");
            }
            return allAvailableRooms;
        }
    }
}
