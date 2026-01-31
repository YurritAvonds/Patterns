namespace Patterns.Factory;

public interface IPackage
{
	/// <summary>
	/// Based on combination of contents and packaging, determine whether the package is okay for shipping.
	/// </summary>
	/// <returns></returns>
	bool HasAcceptableContent();

	/// <summary>
	/// Total weight, including packaging
	/// </summary>
	double TotalWeight { get; }

}
