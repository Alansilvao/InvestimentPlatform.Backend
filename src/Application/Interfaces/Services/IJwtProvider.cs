using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Application.Interfaces.Services;

[ExcludeFromCodeCoverage]
public class TokenInfo
{
	public string Email { get; set; }
	public string Name { get; set; }
}

public interface IJwtProvider
{
	string GenerateToken(Client client);
	TokenInfo DecodeToken(string token);
}