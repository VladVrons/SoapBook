using System.Collections.Generic;

namespace FrontEnd.Models
{
	public class UserModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		private string Password { get; set; }
		public List<string> Tags { get; set; } 
		public UserModel(string pass) 
		{
			Password = pass;	
		}
	}
}
