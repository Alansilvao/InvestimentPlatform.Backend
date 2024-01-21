namespace Domain.Entities;

public class Client
{
    public int Id { get; }
    public string Name { get; }
	public string Email { get; }
	public string Password { get; }

    public virtual Account Account { get; set; }

    public Client(string name, string email, string password)
	{
		Name = name;
		Email = email;
		Password = password;
	}
}