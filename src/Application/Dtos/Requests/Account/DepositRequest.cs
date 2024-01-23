using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.Dtos.Requests.Account;

[ExcludeFromCodeCoverage]
public class DepositRequest
{
	[Required(ErrorMessage = "Deposit value is required")]
	[Range(1, int.MaxValue, ErrorMessage = "Deposit value must be greater than 0")]
	public int Value { get; set; }
}