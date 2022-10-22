using Client.Models;

namespace Client.Repos.Interface
{
    public interface IOfferRepository
    {
        public Task<Offer> AddOffer(Offer offer);
        public Task<List<Offer>> GetAllOffers();
        public Task<Offer> GetOfferById(int id);
        public Task<List<Offer>> GetAllAcceptedOffers();
        public Task<Offer> AcceptOffer(Offer offer);
    }
}
