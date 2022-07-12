using DistanceCalculator.WebAPI.Contracts;
using DistanceCalculator.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

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

            var culture = CultureInfo.CurrentCulture;

            var distance = distanceCalculationService.CalculateDistance(dto, calculationType);

            return Ok(TransformDistance(distance));
        }

        private static double TransformDistance(double distance)
        {
            double res = 0;
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "en-US":
                    res = distance * 0.0006213712;
                    break;
                case "uk-UA":
                    res = distance * 0.001;
                    break;
                default:
                    res = distance;
                    break;
            }
            return Math.Round(res, 3);
        }
    }
}
