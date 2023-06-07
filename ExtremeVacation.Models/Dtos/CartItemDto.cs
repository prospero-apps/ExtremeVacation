using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeVacation.Models.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public int CartId { get; set; }
        public string TripName { get; set; }
        public string TripDestination { get; set; }
        public string TripDescription { get; set; }
        public string TripImageURL { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Duration { get; set; }
    }
}
