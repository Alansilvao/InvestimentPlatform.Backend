using Domain.Enums;

namespace Domain.Entities;

public class AccountTransaction
{
    public AccountTransaction(int accountId, TransactionType transactionType, decimal amount)
	{
		AccountId = accountId;
		TransactionType = transactionType;
		Amount = amount;
	}

    public int Id { get; }
    public int AccountId { get; }
    public TransactionType TransactionType { get; }
    public decimal Amount { get; }
    public DateTime CreatedAt { get; } = DateTime.Now;
}