using Application.Exceptions;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class AssetsRepository : IAssetsRepository
{
    private readonly ApplicationDbContext _context;

    public AssetsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> PostAssetsAsync(string symbol, string name, int availableQuantity, decimal price)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(c => c.Symbol == symbol);

        if (asset is not null)
            throw new HttpStatusException(StatusCodes.Status400BadRequest, "Existing asset symbol");

        var newAsset = new Asset(symbol, name, availableQuantity, price);

        await _context.AddAsync(newAsset);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Asset>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await _context.Assets.ToListAsync(cancellationToken);

    public async Task<Asset?> GetBySymbolAsync(string symbol, CancellationToken cancellationToken = default)
        => await _context.Assets.FirstOrDefaultAsync(it => it.Symbol == symbol, cancellationToken);
}