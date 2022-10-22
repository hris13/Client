using AutoMapper;
using Client.dto;
using Client.Models;
using Client.Repos.Interface;
using Client.services.Interface;
using System;
using System.Security.Principal;

namespace Client.services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;
        private readonly ICalculateService _calculateService;
        


        public OfferService(IOfferRepository offerRepository, IMapper mapper, ICalculateService calculateService)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
            _calculateService = calculateService;
            
        }

        public async Task<Offer> AcceptOffer(int id)
        {
            Offer offer = await _offerRepository.GetOfferById(id);
            offer.Status = true;
            return offer;
        }

        public async Task<CreateDTO> AddOffer(CreateDTO offer)
        {
            Offer newoffer = _mapper.Map<Offer>(offer);
            newoffer.Price = (decimal?)await _calculateService.PriceCalculator(offer);
            newoffer.Quantity = await _calculateService.TimeCalculator(offer);
            await _offerRepository.AddOffer(newoffer);
            return offer;
        }

        public async Task<List<OfferDTO>> GetAllAcceptedOffers()
        {
            List<Offer> list = await _offerRepository.GetAllAcceptedOffers();
            List<OfferDTO> newlist = _mapper.Map<List<OfferDTO>>(list);
            return newlist;
        }

        public async Task<List<OfferDTO>> GetAllOffers()
        {
            List<Offer> list = await _offerRepository.GetAllOffers();
            List<OfferDTO> newlist = _mapper.Map<List<OfferDTO>>(list);
            return newlist;
        }
       
    }
}
