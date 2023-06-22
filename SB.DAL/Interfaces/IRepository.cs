using SB.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.DAL.Interfaces
{
		public interface IRepository<TDbModel> where TDbModel : class
		{
			public List<TDbModel> GetAll();
			public User Get(string name);
			public void Delete(string email);
			public void Update(TDbModel model);
			public TDbModel Add(TDbModel model);
		}
	
}
