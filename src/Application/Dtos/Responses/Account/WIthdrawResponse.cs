using System.Diagnostics.CodeAnalysis;

namespace Application.Dtos.Responses.Account;

[ExcludeFromCodeCoverage]
public class WithdrawResponse
{
	public string Message { get; } = "Withdraw successfully";
}
