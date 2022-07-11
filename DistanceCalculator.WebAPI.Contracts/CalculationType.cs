namespace DistanceCalculator.WebAPI.Contracts
{
    public enum CalculationType
    {
        /// <summary>
        /// Spherical Law of Cosines
        /// </summary>
        Default = 0,

        /// <summary>
        /// Haversine formula
        /// </summary>
        Haversine = 1,
    }
}
