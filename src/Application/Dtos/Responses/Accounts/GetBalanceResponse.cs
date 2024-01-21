namespace Application.Dtos.Responses.Accounts;

public class GetBalanceResponse
{
	public decimal AvailableBalance { get; set; }

	public GetBalanceResponse(decimal availableBalance)
	{
		AvailableBalance = availableBalance;
	}
}