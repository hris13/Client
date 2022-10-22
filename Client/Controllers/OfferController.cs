using Client.dto;
using Client.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferService _offerService;
        public OfferController(OfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        public async Task<IActionResult>CreateOffer(CreateDTO offer)

        {
            await _offerService.AddOffer(offer);
            return Ok("Offer Created");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAcceptedOffers()
        {
            await _offerService.GetAllAcceptedOffers();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOffers()
        {
            await _offerService.GetAllOffers();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AcceptOffer(int id)
        {
            await _offerService.AcceptOffer(id);
            return Ok("Offer accepted");
        }
    }
}
