namespace Patterns.Standard.Strategy;

public class FirstStrategy : IStrategy
{
    public double FirstMethod(double firstParameter, double secondParameter)
        => firstParameter + secondParameter;

    public string SecondMethod(string firstParamater)
        => $"First Strategy received parameter {firstParamater}.";
}
