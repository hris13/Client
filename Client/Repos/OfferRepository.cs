using Client.Models;
using Client.Repos.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Client.Repos
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ClientContext _ctx;
        public OfferRepository(ClientContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Offer> AcceptOffer(Offer offer)
        {
            _ctx.Offers.Update(offer);
            await _ctx.SaveChangesAsync();
            return offer;

        }

        public async Task<Offer> AddOffer(Offer offer)
        {
            _ctx.Offers.Add(offer);
            await _ctx.SaveChangesAsync();
            return offer;
        }

        public async Task<List<Offer>> GetAllAcceptedOffers()
        {
            return await _ctx.Offers.Where(x => x.Status == true).ToListAsync();
            
        }

        public async Task<List<Offer>> GetAllOffers()
        {
            return await _ctx.Offers.ToListAsync();
        }

        public async Task<Offer> GetOfferById(int id)
        {
            var offer = await _ctx.Offers.FirstOrDefaultAsync(o => o.OfferId == id) ;
            return offer;
        }
    }
}
