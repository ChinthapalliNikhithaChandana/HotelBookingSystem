﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAvailabilityService.Models
{
    public class Availablehotels
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int AvailableRooms { get; set; }
        public int CostPerDay { get; set; }
    }
}
