using BookingService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> GetAll();
        public Task<IEnumerable<Booking>> GetByUserId(int id);
        public Task<Booking> AddBooking(Booking entity);
    }
}
