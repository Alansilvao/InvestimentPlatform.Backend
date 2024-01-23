using Application.Dtos.Responses.Investments;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Database.Repositories;

[ExcludeFromCodeCoverage]
public class PortfolioRepository : IPortfolioRepository
{
	private readonly ApplicationDbContext _context;

	public PortfolioRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> IncrementPortfolioAsync
		(Asset asset, int purchasedQuantity, string accountId)
	{
		var portfolio = await _context.Portfolios.FirstOrDefaultAsync
		(
			p => p.AccountId == accountId && p.AssetId == asset.Id
		);

		var account = await _context.Accounts.FirstOrDefaultAsync
		(
			a => a.Id == accountId
		);

		account!.Balance += purchasedQuantity * asset.Price;

		await _context.InvestmentsHistory.AddAsync
		(
			new InvestmentsHistoryModel
			{
				AccountId = accountId,
				InvestmentType = "Buy",
				Price = asset.Price,
				Quantity = purchasedQuantity,
				AssetId = asset.Id
			}
		);

		if (portfolio is null)
			return await InsertPortfolioAsync(asset, purchasedQuantity, accountId);
		return await UpdatePortfolioAsync(portfolio, asset, purchasedQuantity);
	}

	public async Task<bool> DecrementPortfolioAsync
		(Asset asset, int soldQuantity, string accountId)
	{
		var assertPortfolio = await _context.Portfolios.FirstOrDefaultAsync
		(
			p => p.AccountId == accountId && p.Symbol == asset.Symbol
		);

		if (assertPortfolio is null)
			return false;

		assertPortfolio.Quantity -= soldQuantity;

		var account = await _context.Accounts.FirstOrDefaultAsync
		(
			a => a.Id == accountId
		);

		account!.Balance += soldQuantity * asset.Price;
		await _context.InvestmentsHistory.AddAsync
		(
			new InvestmentsHistoryModel
			{
				AccountId = accountId,
				AssetId = asset.Id,
				InvestmentType = "Sell",
				Price = asset.Price,
				Quantity = soldQuantity
			}
		);

		switch (assertPortfolio.Quantity)
		{
			case < 0:
				return false;
			case 0:
				_context.Portfolios.Remove(assertPortfolio);
				return await _context.SaveChangesAsync() > 0;
			default:
				_context.Portfolios.Update(assertPortfolio);
				return await _context.SaveChangesAsync() > 0;
		}
	}

	private async Task<bool> UpdatePortfolioAsync
		(PortfolioModel portfolio, Asset asset, int purchasedQuantity)
	{
		portfolio.Quantity += purchasedQuantity;
		portfolio.AcquisitionValue += purchasedQuantity * asset.Price;
		portfolio.UpdatedAt = DateTime.Now;
		_context.Portfolios.Update(portfolio);
		return await _context.SaveChangesAsync() > 0;
	}

	private async Task<bool> InsertPortfolioAsync
		(Asset asset, int purchasedQuantity, string accountId)
	{
		var portfolio = new PortfolioModel
		{
			AccountId = accountId,
			AssetId = asset.Id,
			Quantity = purchasedQuantity,
			Symbol = asset.Symbol,
			ProfitabilityPercentage = 0,
			ProfitabilityValue = 0,
			AveragePurchasePrice = asset.Price,
			CurrentValue = asset.Price,
			AcquisitionValue = asset.Price * purchasedQuantity
		};

		await _context.Portfolios.AddAsync(portfolio);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<GetPortfolioResponse> GetPortfolioAsync(string clientEmail)
	{
        return null;
	}
}
