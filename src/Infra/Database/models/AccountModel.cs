using System.ComponentModel.DataAnnotations;

namespace Infra.Database.models;

public class AccountModel
{
	[Key] [Required]
	public string Id { get; set; } = string.Empty;
}