using DistanceCalculator.WebAPI.Contracts;
using DistanceCalculator.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistanceCalculator.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceCalculator : Controller
    {
        private readonly IDistanceCalculationService distanceCalculationService;

        public DistanceCalculator(IDistanceCalculationService distanceCalculationService)
        {
            this.distanceCalculationService = distanceCalculationService;
        }

        /// <summary>
        /// Returns distance between two points in meters
        /// </summary>
        /// <param name="dto">Request dto</param>
        /// <param name="calculationType">Calculation type</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CalculateDistance(GetDistanceRequestDTO dto, CalculationType calculationType)
        {
            var distance = distanceCalculationService.CalculateDistance(dto, calculationType);

            return Ok(distance);
        }
    }
}
