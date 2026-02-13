namespace Patterns.Standard.Strategy;

public class SecondStrategy : IStrategy
{
    public double FirstMethod(double firstParameter, double secondParameter)
    {
        return firstParameter * secondParameter;
    }

	public string SecondMethod(string firstParamater)
	{
        return $"Second Strategy received parameter {firstParamater}.";
    }
}
