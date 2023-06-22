using SB.DAL.Interfaces;
using SB.DAL.Models;
using System.Data.Entity;

namespace SB.DAL.Repositories
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

        public void Delete(string email)
        {
            var toDelete = Context.Set<User>().FirstOrDefault(m => m.Email == email);
            Context.Set<User>().Remove(toDelete);
            Context.SaveChanges();
        }

        public User Get(string name)
        {
            //Console.WriteLine(Context.Set<User>().FirstOrDefault(m => m.Name == name).Email);
            return new User("qwerty") { Name = "ghj" };
		}

		public List<User> GetAll()
        {
            return Context.Set<User>().ToList();
        }

        public void Update(User model)
        {
			Context.Entry(model).State = EntityState.Modified;

        }

	}

}
