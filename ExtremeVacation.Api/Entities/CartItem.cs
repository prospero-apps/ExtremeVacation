namespace ExtremeVacation.Api.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int TripId { get; set; }
        public int Duration { get; set; }
    }
}
