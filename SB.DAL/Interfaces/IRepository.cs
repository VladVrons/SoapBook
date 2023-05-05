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
			public TDbModel Get(int id);
			public void Delete(int id);
			public TDbModel Update(TDbModel model);
			public TDbModel Add(TDbModel model);
		}
	
}
