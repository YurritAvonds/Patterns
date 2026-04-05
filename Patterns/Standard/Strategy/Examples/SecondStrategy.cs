namespace Patterns.Standard.Strategy;

public class SecondStrategy : IStrategy
{
    public double FirstMethod(double firstParameter, double secondParameter)
        => firstParameter * secondParameter;

    public string SecondMethod(string firstParamater)
        => $"Second Strategy received parameter {firstParamater}.";
}
