using SB.DAL.Interfaces;
using SB.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.DAL.Repositories
{
	public class MessageRepository : IRepository<Message>
	{
		public Message Add(Message model)
		{
			throw new NotImplementedException();
		}

		public void Delete(string email)
		{
			throw new NotImplementedException();
		}

		public Message Get(string email)
		{
			throw new NotImplementedException();
		}

		public List<Message> GetAll()
		{
			throw new NotImplementedException();
		}

		public Message Update(Message model)
		{
			throw new NotImplementedException();
		}
	}
}
