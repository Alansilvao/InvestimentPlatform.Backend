using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAssetsRepository
{
    Task<IEnumerable<Asset>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Asset?> GetBySymbolAsync(string symbol, CancellationToken cancellationToken = default);
    Task<bool> PostAssetsAsync(string symbol, string? name, int availableQuantity, decimal price);
}