using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.DAL.Models
{
	public class Message
	{
		public string ChatId { get; set; }
		public string Text { get; set; }
		public Message(User user1, User user2, string text)
		{
			ChatId = user1.Email + user2.Email;
			Text = text;
		}
	}
}
