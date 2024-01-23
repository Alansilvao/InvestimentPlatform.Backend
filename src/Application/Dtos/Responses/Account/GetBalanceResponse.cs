using System.Diagnostics.CodeAnalysis;

namespace Application.Dtos.Responses.Account;

[ExcludeFromCodeCoverage]
public class GetBalanceResponse
{
	public decimal AvailableBalance { get; set; }

	public GetBalanceResponse(decimal availableBalance)
	{
		AvailableBalance = availableBalance;
	}
}