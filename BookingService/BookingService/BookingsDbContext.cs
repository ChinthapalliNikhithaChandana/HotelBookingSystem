using BookingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService
{
    public class BookingsDbContext:DbContext
    {
        public BookingsDbContext(DbContextOptions<BookingsDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Booking> Bookings { get; set; }
    }
}
