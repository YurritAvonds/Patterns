namespace Patterns.Strategy;

public class CarRouteCalculator : IRouteCalculator
{
	public double CalculateDistance(string departureLocation, string destionationLocation)
	{
		return 66.2;
	}

	public string ReportDestinationWarning(string destionationLocation)
	{
		return $"Destination {destionationLocation} will be closed by the time you arrive.";
	}
}
