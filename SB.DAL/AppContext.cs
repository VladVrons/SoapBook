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
			db.Users.Add(new User("1234") { Email="342312", Name="weq"  }); ; ;
			db.SaveChanges();
		}
	}
}
