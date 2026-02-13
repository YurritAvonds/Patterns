namespace Patterns.Strategy;

public class FirstStrategy : IStrategy
{
    public double FirstMethod(double firstParameter, double secondParameter)
    {
        return firstParameter + secondParameter;
    }

    public string SecondMethod(string firstParamater)
    {
        return $"First Strategy received parameter {firstParamater}.";
    }
}
