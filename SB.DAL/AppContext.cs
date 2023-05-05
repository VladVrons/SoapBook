using Microsoft.EntityFrameworkCore;
using SB.DAL.Models;

namespace SB.DAL
{
	public class AppContext : DbContext
	{
		public DbSet<User> Users { get; set; }


		public AppContext(DbContextOptions<AppContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
