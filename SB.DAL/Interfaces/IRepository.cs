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
			public TDbModel Get(string email);
			public void Delete(string email);
			public TDbModel Update(TDbModel model);
			public TDbModel Add(TDbModel model);
		}
	
}
