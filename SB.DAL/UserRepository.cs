
using SB.DAL.Interfaces;
using SB.DAL.Models;

namespace SB.DAL
{
	public class UserRepository : IRepository<User>
	{
		private AppContext Context;
		public UserRepository(AppContext context)
		{
			Context = context;
		}

		public User Add(User model)
		{
			Context.Set<User>().Add(model);
			Context.SaveChanges();
			return model;
		}

		public void Delete(int id)
		{
			var toDelete = Context.Set<User>().FirstOrDefault(m => m.Id == id);
			Context.Set<User>().Remove(toDelete);
			Context.SaveChanges();
		}

		public User Get(int id)
		{
			return Context.Set<User>().FirstOrDefault(m => m.Id == id);
		}

		public List<User> GetAll()
		{
			return Context.Set<User>().ToList();
		}

		public User Update(User model)
		{
			var toUpdate = Context.Set<User>().FirstOrDefault(m => m.Id == model.Id);
			if (toUpdate != null)
			{
				toUpdate = model;
			}
			Context.Update(toUpdate);
			Context.SaveChanges();
			return toUpdate;

		}
	}

}
