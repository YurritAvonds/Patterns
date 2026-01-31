namespace Patterns.Strategy;

public interface IRouteCalculator
{
	double CalculateDistance(string departureLocation, string destionationLocation);
	string ReportDestinationWarning(string destionationLocation);
}
