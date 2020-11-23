using HotelAvailabilityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAvailabilityService.Repository
{
    public interface IAvailabilityRepository
    {
        public Task<Availablehotels> GetById(int id);
        public Task<IEnumerable<Availablehotels>> GetAll();
        public Task<bool> Reduce(int id);
        public Task<Availablehotels> AddHotel(Availablehotels hotel);
    }
}
