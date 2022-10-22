using Client.dto;
using Client.Models;

namespace Client.services.Interface
{
    public interface IOfferService
    {
        public Task<CreateDTO> AddOffer(CreateDTO offer);
        public Task<List<OfferDTO>> GetAllOffers();
        public Task<List<OfferDTO>> GetAllAcceptedOffers();
        public Task<Offer> AcceptOffer(int id);
    }
}
