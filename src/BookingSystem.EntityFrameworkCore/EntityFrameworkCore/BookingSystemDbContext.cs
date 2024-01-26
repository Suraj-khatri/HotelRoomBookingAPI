using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BookingSystem.Authorization.Roles;
using BookingSystem.Authorization.Users;
using BookingSystem.MultiTenancy;
using BookingSystem.Models;
using System;

namespace BookingSystem.EntityFrameworkCore
{
    public class BookingSystemDbContext : AbpZeroDbContext<Tenant, Role, User, BookingSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DbSet<Room> Room {  get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<RoomBooking> roomBooking { get; set; }

        public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options)
            : base(options)
        {
        }
    }
}
