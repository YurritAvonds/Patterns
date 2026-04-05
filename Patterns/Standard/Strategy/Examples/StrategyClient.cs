namespace Patterns.Standard.Strategy;

public class StrategyClient(IStrategy strategy)
{
    public double ExecuteFirstMethod(double firstParameter, double secondParameter)
        => strategy.FirstMethod(firstParameter, secondParameter);

    public string ExecuteSecondMethod(string firstParameter)
        => strategy.SecondMethod(firstParameter);
}
