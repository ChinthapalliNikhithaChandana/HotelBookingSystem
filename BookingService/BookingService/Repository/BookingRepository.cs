using BookingService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingsDbContext bookingsDbContext;
        //private readonly AvailabilityDbContext availabilityDbContext;
        public BookingRepository(BookingsDbContext bookingsDbContext)
        {
            this.bookingsDbContext = bookingsDbContext;
        }

        public async Task<Booking> AddBooking(Booking entity)
        {
            

                bookingsDbContext.Bookings.Add(entity);
                int count = await bookingsDbContext.SaveChangesAsync();
                return entity;
            

        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            var bookings = await bookingsDbContext.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<IEnumerable<Booking>> GetByUserId(int id)
        {
            var bookings = await bookingsDbContext.Bookings.Where(x => x.UserId == id).ToListAsync();
            return bookings;
        }
    }
}
