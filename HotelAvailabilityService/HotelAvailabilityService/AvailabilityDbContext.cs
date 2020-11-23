using HotelAvailabilityService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAvailabilityService
{
    public class AvailabilityDbContext:DbContext
    {
        public AvailabilityDbContext(DbContextOptions<AvailabilityDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Availablehotels> Hotels { get; set; }
    }
}
