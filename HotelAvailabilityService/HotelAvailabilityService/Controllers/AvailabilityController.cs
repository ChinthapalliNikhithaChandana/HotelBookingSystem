using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAvailabilityService.Models;
using HotelAvailabilityService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAvailabilityService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityRepository repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AvailabilityController));
        public AvailabilityController(IAvailabilityRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                _log4net.Info("Getting details of all Hotels");
                return new OkObjectResult(await repository.GetAll());
            }
            catch
            {
                _log4net.Error("Error in Getting Hotel Details");
                return new NoContentResult();
            }

        }
        [HttpGet("{id}", Name = "Find Hotel")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                _log4net.Info("Getting details of Hotel with  hotelid : " + id);
                return  Ok(await repository.GetById(id));
            }
            catch
            {
                _log4net.Error("Error in Getting Hotel  Details with hotel id : " + id);
                return new NoContentResult();
            }
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> Post(int id)
        {
            try
            {
                _log4net.Info("Hotel Count  decremented for hotelid : " + id);
                return Ok(await repository.Reduce(id));
            }
            catch
            {
                _log4net.Error("Error in decrementing hotel count for hotel id :" + id);
                return new NoContentResult();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Availablehotels hotel)
        {
            try
            {
                _log4net.Info("Adding hotel with id" + hotel.Id);
                return Ok(await repository.AddHotel(hotel));
            }
            catch
            {
                _log4net.Error("Error in adding hotel with id " + hotel.Id);
                return new NotFoundObjectResult("Not updated");
            }
        }
    }
}