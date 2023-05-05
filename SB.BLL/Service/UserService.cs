using SB.DAL.Interfaces;
using SB.DAL.Models;


namespace SB.BLL.Service
{
	public class UserService
	{
		private IRepository<User> Users { get; set; }

		public bool LogIn(string email, string pass)
		{
			var user = Users.Get(email);
			if (user == null)
			{
				return false;
			}
			if (user.PassCheck(pass))
			{
				return true;
			}else return false;

		}

		public void SignUp(string name, string email, string password)
		{
			Users.Add(new User(password) { Name = name, Email = email} );
		}

		public void EditProfile() { }
	}
}
