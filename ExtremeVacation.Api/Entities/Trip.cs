using System.ComponentModel.DataAnnotations.Schema;

namespace ExtremeVacation.Api.Entities
{
    public class Trip
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

        [ForeignKey("CategoryId")]
        public TripCategory TripCategory { get; set; }
    }
}
