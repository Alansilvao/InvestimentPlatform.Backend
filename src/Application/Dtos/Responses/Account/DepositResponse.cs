using System.Diagnostics.CodeAnalysis;

namespace Application.Dtos.Responses.Account;

[ExcludeFromCodeCoverage]
public class DepositResponse
{
	public string Message { get; } = "Deposit successfully";
}
