namespace Patterns.Strategy;

public class TrainRouteCalculator : IRouteCalculator
{
	public double CalculateDistance(string departureLocation, string destionationLocation)
	{
		return 85.4;
	}

	public string ReportDestinationWarning(string destionationLocation)
	{
		return $"The train station is more than 5km from {destionationLocation}";
	}
}
