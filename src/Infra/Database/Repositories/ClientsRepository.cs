using Application.Dtos.Responses.Accounts;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class ClientsRepository : IClientsRepository
{
	private readonly ApplicationDbContext _context;

	public ClientsRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> CreateAsync(Client client)
	{
		if (await _context.Clients.AddAsync(client) is null)
			return false;

		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<Client?> GetByEmailAsync(string requestEmail)
	{
		var client = await _context.Clients.FirstOrDefaultAsync
			(client => client.Email == requestEmail);
		return client is null ? null : new Client(client.Name, client.Email, client.Password);
	}

	public async Task<Account?> GetClientAccountAsync(string clientEmail)
	{
        return null;
        /*
		
		var client = await _context.Clients.Include(c => c.Account).FirstOrDefaultAsync
			(client => client.Email == clientEmail);
		if (client is null)
			return null;
		return new Account
		(
			client.Account!.Id, client.Account.ClientId, client.Account.Balance
		);*/
	}

	public async Task<GetTransactionsExtractResponse> GetTransactionsExtractAsync
		(string clientEmail)
	{
		return null;
		/*
		var client = await _context.Clients.Include(c => c.Account).FirstOrDefaultAsync
			(client => client.Email == clientEmail);
		var account = client!.Account;

		var accountTransactions = await _context.TransactionHistory.Where
			(transaction => transaction.AccountId == account!.Id).ToListAsync();

		var investmentTransactions = await _context.InvestmentsHistory.Where
			(transaction => transaction.AccountId == account!.Id).ToListAsync();

		return new GetTransactionsExtractResponse
		{
			AccountTransactions = accountTransactions.Select
			(
				transaction => new AccountTransaction
				(
					transaction.Id, transaction.TransactionType, transaction.Value,
					transaction.CreatedAt
				)
			),
			InvestmentsTransactions = investmentTransactions.Select
			(
				transaction => new InvestmentTransaction
				(
					transaction.Id, transaction.AssetId,
					transaction.Price, transaction.InvestmentType, transaction.CreatedAt
				)
			)
		};

		*/
    }
}
