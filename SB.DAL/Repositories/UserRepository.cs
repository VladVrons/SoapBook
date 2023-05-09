using SB.DAL.Interfaces;
using SB.DAL.Models;

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

        public User Get(string Email)
        {
            return Context.Set<User>().FirstOrDefault(m => m.Email == Email);
        }

        public List<User> GetAll()
        {
            return Context.Set<User>().ToList();
        }

        public User Update(User model)
        {
            var toUpdate = Context.Set<User>().FirstOrDefault(m => m.Email == model.Email);
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
