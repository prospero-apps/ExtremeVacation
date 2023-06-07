using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeVacation.Models.Dtos
{
    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public string Danger { get; set; }
        public int ChanceOfSurvival { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
