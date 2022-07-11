using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.WebAPI.Contracts;
using DistanceCalculator.WebAPI.Services.Interfaces;

namespace DistanceCalculator.WebAPI.Services
{
    public class DistanceCalculatorFactory : IDistanceCalculatorFactory
    {
        public CalculatorBase GetCalculator(CalculationType calculationType)
        {
            switch (calculationType)
            {
                case CalculationType.Default:
                    return new DeafaultCalculator();
                case CalculationType.Haversine:
                    return new HaversineCalculator();
                default:
                    return new DeafaultCalculator();
            }
        }
    }
}
