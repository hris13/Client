using AutoMapper;
using Client.dto;
using Client.Models;

namespace Client.mapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Offer, OfferDTO>().ReverseMap();
        }
        
    }
}
