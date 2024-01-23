using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

[ExcludeFromCodeCoverage]
public class Client
{
    public int Id { get; }
    public string Name { get; }
	public string Email { get; }
	public string Password { get; }

    public Client(string name, string email, string password)
	{
		Name = name;
		Email = email;
		Password = password;
	}
}