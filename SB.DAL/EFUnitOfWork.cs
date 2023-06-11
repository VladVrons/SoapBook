using SB.DAL.Interfaces;
using SB.DAL.Repositories;

namespace SB.DAL
{
	public class EFUnitOfWork
	{
		private AppContext db;
		private UserRepository userRepository;

		public EFUnitOfWork(string connectionstring)
		{
			AppContext db = new AppContext(connectionstring);
		}

		public UserRepository Users
		{
			get
			{
				if (userRepository == null)
					userRepository = new UserRepository(db);
				return userRepository;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
