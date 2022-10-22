namespace Client.dto
{
    public class OfferDTO
    {
        public int OfferId { get; set; }
        public int Quantity { get; set; }
        public string MaterialName { get; set; }
        public decimal? Price { get; set; }
        public int? Time { get; set; }
        public bool? Status { get; set; }

    }
}
