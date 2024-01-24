using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

[ExcludeFromCodeCoverage]
public class Asset
{
	public int Id { get; set; }
	public string Symbol { get; set; }
	public string Name { get; set; }
	public int AvailableQuantity { get; set; }
	public decimal Price { get; set; }
    public decimal MarketValue { get; private set; }

    public Asset(string symbol, string name, int availableQuantity, decimal price)
	{
        Symbol = symbol;
		Name = name;
		AvailableQuantity = availableQuantity;
		Price = price;
		MarketValue = availableQuantity * price;
	}
}