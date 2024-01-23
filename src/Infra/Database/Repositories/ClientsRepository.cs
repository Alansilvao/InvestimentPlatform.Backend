using Application.Dtos.Responses.Account;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
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
        
	}

	public async Task<GetTransactionsExtractResponse> GetTransactionsExtractAsync
		(string clientEmail)
	{
		return null;
		
    }
}
