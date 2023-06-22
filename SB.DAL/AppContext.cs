using Microsoft.EntityFrameworkCore;
using SB.DAL.Models;
using System.Data.Entity;

namespace SB.DAL
{
	public class AppContext : System.Data.Entity.DbContext
    {
		public System.Data.Entity.DbSet<User> Users { get; set; }
		public System.Data.Entity.DbSet<Message> Messages { get; set; }

		static AppContext()
		{
			Database.SetInitializer<AppContext>(new AppDbInitializer());
		}

		public AppContext(string connectionString) : base(connectionString)
		{

		}
	}
	public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
	{
		protected override void Seed(AppContext db)
		{
			Console.WriteLine("seed");
			var u1 = new User("1234") { Email = "342312", Name = "user1" };
			var u2 = new User("1234") { Email = "342312", Name = "user2" };
			db.Users.Add(u1);
			db.Users.Add(u2);
			db.Messages.Add(new Message(u1, u2, "hello world"));
			db.SaveChanges();
		}
	}
}
