namespace Patterns.Standard.Factory.Examples;

public interface IBaseType
{
    /// <summary>
    /// Some method for illustration purposes, that does something with the properties of the object.
    /// </summary>
    /// <returns>A boolean value depending on what the implementation does.</returns>
    public bool Method();

    /// <summary>
    /// A type of property that is common to all the objects produced by any factory.
    /// </summary>
    public double CommonProperty { get; }
}
