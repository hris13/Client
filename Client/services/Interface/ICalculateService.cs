using Client.dto;

namespace Client.services.Interface
{
    public interface ICalculateService
    {
        public Task<double> PriceCalculator(CreateDTO offer);
        public Task<int> TimeCalculator(CreateDTO offer);
    }
}
