namespace Patterns.Factory;

public class FragilePackage : IPackage
{
	public string ContentDescription { get; init; }
	public double ContentWeight { get; init; }
	public Packaging Packaging {  get; set; }

	const double MaximumAcceptableWeight = 0.8;

	public FragilePackage() 
	{
		ContentDescription = string.Empty;
		ContentWeight = MaximumAcceptableWeight;
		Packaging = Packaging.None;
	}

	public FragilePackage(string contentDescription, double contentWeight, Packaging packaging)
	{
		ContentDescription = contentDescription;
		ContentWeight = contentWeight;
		Packaging = packaging;
	}

	public double TotalWeight => ContentWeight;

	/// <summary>
	/// Any package that has a box is acceptable.
	/// </summary>
	private bool HasAccetpablePackaging => Packaging.HasFlag(Packaging.BubbleWrapAndBox);
	private bool HasAcceptableWeight => TotalWeight <= MaximumAcceptableWeight;
	public bool HasAcceptableContent() => HasAccetpablePackaging && HasAcceptableWeight;
}
