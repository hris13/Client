using Client.dto;
using Client.Models;
using Client.Repos;
using Client.Repos.Interface;
using Client.services.Interface;
using System;

namespace Client.services
{
    public class CalculateService:ICalculateService
    {
        private readonly IMaterialRepository _materialRepository;
        public CalculateService( IMaterialRepository materialRepository)
        {
            
            _materialRepository = materialRepository;
        }
        public async Task< double> PriceCalculator(CreateDTO offer)
        {
            List<Material> m = await _materialRepository.GetMaterials();
            double price = 0;
            int temp = 0;
            int watertemp = 0;
            for (int i = 0; i <= m.Count; i++)
            {
                if (m[i].MaterialName == offer.MaterialName)
                    temp = i;

                if (m[i].MaterialName == "water")
                    watertemp = i;

            }
            if (m[temp].MaterialName == "cotton")
            {
                price += 3 * (double)m[watertemp].MaterialPrice;
            }
            if (m[temp].MaterialName == "sand")
            {
                price += 2 * (double)m[watertemp].MaterialPrice;
            }

            price += (double)(m[temp].MaterialPrice * offer.Quantity);
            return price;
        }
        public async Task<int>  TimeCalculator(CreateDTO offer)
        {
            
            double price = await PriceCalculator(offer);
            int time = 0;
            if (price <= 10)
                time = 1;
            if (price > 10&&price<=25)
                time = 7;
            if (price >25&&price<=100)
                time = 45;
            if (price >100)
                time = 120;
            int quantity = (int)offer.Quantity;
            if (quantity > 3 && quantity <= 12)
                time += 3;
            if (quantity > 12 && quantity <= 50)
                time += 21;
            if (quantity >50)
                time += 60;

            return time;
        }
    }
}
