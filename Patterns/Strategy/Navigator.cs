namespace Patterns.Strategy;

public class Navigator
{
	IRouteCalculator RouteCalculator;
	string DepartureLocation { get; set; }
	string DestinationLocation { get; set; }

	public Navigator(IRouteCalculator routeCalculator, string departureLocation, string destinationLocation)
	{
		RouteCalculator = routeCalculator;
		DepartureLocation = departureLocation;
		DestinationLocation = destinationLocation;
	}

	public void SetStrategy(IRouteCalculator routeCalculator)
	{
		RouteCalculator = routeCalculator;
	}

	public double CalculateDistance()
	{
		return RouteCalculator.CalculateDistance(DepartureLocation, DestinationLocation);
	}

	public string ReportDestinationWarning()
	{
		return RouteCalculator.ReportDestinationWarning(DestinationLocation);
	}
}
