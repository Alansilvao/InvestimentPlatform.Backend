using Domain.Entities;
using System.Diagnostics.CodeAnalysis;
namespace Application.Dtos.Responses.Account;

[ExcludeFromCodeCoverage]
public class GetTransactionsExtractResponse
{
	public IEnumerable<InvestmentTransaction> InvestmentsTransactions { get; set; } = null!;
	public IEnumerable<AccountTransaction> AccountTransactions { get; set; } = null!;
}
