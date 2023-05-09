using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.DAL.Models
{
	public class User
	{
		//public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		private string Password { get; set; }
		public List<string> Tags { get; set; }
		public User(string pass) 
		{
			Password = pass;
		}

		public bool PassCheck(string pass)
		{
			if(pass == Password)
			{
				return true;
			}else return false;
		}
	}
}
