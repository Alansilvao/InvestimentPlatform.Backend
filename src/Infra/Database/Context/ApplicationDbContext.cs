using Domain.Entities;
using Infra.Database.Map;
using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Context;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<Client> Clients { get; set; } = null!;
	public DbSet<Account> Accounts { get; set; } = null!;
	public DbSet<Asset> Assets { get; set; } = null!;
	public DbSet<PortfolioModel> Portfolios { get; set; } = null!;
	public DbSet<InvestmentsHistoryModel> InvestmentsHistory { get; set; } = null!;
	public DbSet<TransactionHistoryModel> TransactionHistory { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfiguration(new AssetMap());
        modelBuilder.ApplyConfiguration(new ClientMap());
        modelBuilder.ApplyConfiguration(new AccountMap());

        base.OnModelCreating(modelBuilder);       
	}
}