using Application.Exceptions;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;
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

    public async Task<bool> PostAssetsAsync
        (string symbol, string? name, int AvailableQuantity, decimal Price)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(c => c.Name == name);

        if (asset is null)
            throw new HttpStatusException(StatusCodes.Status400BadRequest, "Existing asset");

        var requestAsset = new AssetModel
        {
            Symbol = symbol,
            Name = name,
            AvailableQuantity = AvailableQuantity,
            Price = Price
        };
        await _context.AddAsync(requestAsset);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Asset>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var assetsFromDb = await _context.Assets.ToListAsync(cancellationToken);
        var assets = assetsFromDb.Select
        (
            asset => new Asset
            (
                asset.Id,
                asset.Symbol,
                asset.Name,
                asset.AvailableQuantity,
                asset.Price
            )
        );
        return assets;
    }

    public async Task<Asset?> GetBySymbolAsync
        (string symbol, CancellationToken cancellationToken = default)
    {
        var assetFromDb = await _context.Assets.FirstOrDefaultAsync
        (
            asset => asset.Symbol == symbol,
            cancellationToken
        );

        if (assetFromDb is null)
            return null;

        return new Asset
        (
            assetFromDb.Id, assetFromDb.Symbol, assetFromDb.Name, assetFromDb.AvailableQuantity,
            assetFromDb.Price
        );
    }

}