using SB.DAL.Interfaces;
using SB.DAL.Models;


namespace SB.BLL.Service
{
	public class UserService
	{
		public User activeUser;
		private IRepository<User> Users { get; set; }

		public UserService() 
		{ 
			activeUser = new User("1111") { Name = "Guest", Email = "guest@gmail.com", Tags =  "searching web"  };
		}
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
			var user = new User(password) { Name = name, Email = email };
			Users.Add(new User(password) { Name = name, Email = email} );
		}

		public void EditProfile(User user) 
		{
			activeUser = user;
		}
	}
}
