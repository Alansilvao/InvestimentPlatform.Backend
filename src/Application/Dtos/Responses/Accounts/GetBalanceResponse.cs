namespace Application.Dtos.Responses.Accounts;

public class GetBalanceResponse
{
	public decimal Balance { get; set; }

	public GetBalanceResponse(decimal balance)
	{
		Balance = balance;
	}
}