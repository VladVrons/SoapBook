using SB.DAL.Interfaces;
using SB.DAL.Models;


namespace SB.BLL.Service
{
	public class UserService
	{
		public User activeUser;
		private IRepository<User> Users { get; set; }

		public UserService() { }
		public bool LogIn(string name, string pass)
		{
			var user = Users.Get(name);
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

		public void EditProfile(User user) 
		{
			activeUser = user;
		}
	}
}
