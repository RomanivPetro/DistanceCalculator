using DistanceCalculator.Core.Calculators.Abstract;
using DistanceCalculator.Core.Extensions;
using DistanceCalculator.Core.Models;
using System;

namespace DistanceCalculator.Core.Calculators
{
    /// <summary>
    /// Calculates distance using ‘haversine’ formula
    /// </summary>
    public class HaversineCalculator : CalculatorBase
    {
        protected override double CalculateDistance(Point pointA, Point pointB)
        {
            var ph1 = (pointA.Latitude).ToRadians();
            var ph2 = (pointB.Latitude).ToRadians();

            var deltaPh = (pointB.Latitude - pointA.Latitude).ToRadians();
            var deltaL = (pointB.Longitude - pointA.Longitude).ToRadians();

            var a = Math.Sin(deltaPh/2) * Math.Sin(deltaPh*2) + Math.Cos(ph1) * Math.Cos(ph2) * Math.Sin(deltaL/2) * Math.Sin(deltaL/2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));

            var d = Radius * c;

            return d;
        }
    }
}
