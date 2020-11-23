using HotelAvailabilityService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAvailabilityService.Repository
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly AvailabilityDbContext context;
        public AvailabilityRepository(AvailabilityDbContext context)
        {
            this.context = context;
        }

        public async Task<Availablehotels> AddHotel(Availablehotels hotel)
        {
            await context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();
            return hotel;
        }

        public async Task<IEnumerable<Availablehotels>> GetAll()
        {
            var hotelList = await context.Hotels.ToListAsync();
            return hotelList;
        }

        public async Task<Availablehotels> GetById(int id)
        {
            var hotel = await context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<bool> Reduce(int id)
        {
            var hotel = await context.Hotels.FindAsync(id);
            if (hotel == null || hotel.AvailableRooms == 0)
                return false;

            hotel.AvailableRooms = hotel.AvailableRooms - 1;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
