using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingService.Models;
using BookingService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository repository;
        //private readonly IAvailabilityRepository availabilityRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BookingsController));
        public BookingsController(IBookingRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _log4net.Info("Get All BookingDetails ");
                return Ok(await repository.GetAll());
            }
            catch
            {
                _log4net.Error("Error in Getting All Booking Details");
                return new NoContentResult();
            }
        }
        [HttpGet("{id}", Name = "FindBookingByUserId")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _log4net.Info("Get BookingDetails withuser id : " + id);
                var bookings = await repository.GetByUserId(id);
                return Ok(bookings);
            }
            catch
            {
                _log4net.Error("Error in Getting Booking Details with user id : " + id);
                return new NotFoundResult();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Booking booking)
        {
            try
            {
                _log4net.Info("Adding new hotel booking with booking id : " + booking.BookingId);
                var obj = await repository.AddBooking(booking);
                //await availabilityRepository.Reduce(booking.HotelId);
                return Ok(obj);

            }
            catch
            {
                _log4net.Error("Error in adding  Booking with booking Id : " + booking.BookingId);
                return new BadRequestObjectResult("Not added to bookings");
            }
        }
    }
}