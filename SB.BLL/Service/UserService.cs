using SB.DAL;
using SB.DAL.Interfaces;
using SB.DAL.Models;


namespace SB.BLL.Service
{
	public class UserService
	{
		public User activeUser;
		private IRepository<User> Users { get; set; }
		public EFUnitOfWork UoW { get; set; }

		public UserService(string connection) 
		{ 
			UoW = new EFUnitOfWork(connection);
			//Users = UoW.Users;
			activeUser = UoW.Users.Get("user1");
			
		}
		public bool LogIn(string name, string pass)
		{
			var user = UoW.Users.Get(name);
			if (user == null)
			{
				activeUser = new User("1111") { Name = "Guest", Email = "guest@gmail.com", Tags = "searching web" };
				return false;
			}
			if (user.PassCheck(pass))
			{
				activeUser = user;
				return true;
			}else return false;

		}

		public void SignUp(string name, string email, string password)
		{
			var user = new User(password) { Name = name, Email = email };
			activeUser = user;
			UoW.Users.Add(user);
		}

		public void EditProfile(User user) 
		{

			activeUser = user;
		}
	}
}
