using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Core.ViewModels.Account
{
	public class GuestRegisterViewModel
	{
		[Required]
		public string Role { get; set; }
		public IEnumerable<string> Roles { get; set; } = new List<string>();
	}
}
