﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeVacation.Models.Dtos
{
    public class CartItemToAddDto
    {
        public int CartId { get; set; }
        public int TripId { get; set; }
    }
}
