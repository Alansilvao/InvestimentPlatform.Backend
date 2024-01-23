using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.Dtos.Requests.Account;

[ExcludeFromCodeCoverage]
public class WithdrawRequest
{
	[Required(ErrorMessage = "Deposit value is required")]
	[Range(1, int.MaxValue, ErrorMessage = "Withdraw value must be greater than 0")]
	public int Value { get; set; }
}