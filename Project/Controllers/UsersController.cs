using FrontEnd.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FrontEnd.Controllers
{
	[Route("api/[controller]")]
	public class UsersController : Controller	
	{
		
		static readonly List<UserModel> users;
		
		static UsersController()
		{
			users = new List<UserModel>
			{
				new UserModel("123") { Email = Guid.NewGuid().ToString(), Name="Tyler"  },
				new UserModel("321") { Email = Guid.NewGuid().ToString(), Name="Ed" },
			};

		}

		[HttpGet]
		public IEnumerable<UserModel> Get()
		{
			return users;
		}

		[HttpPost]
		public IActionResult Post(UserModel user)
		{
			
			users.Add(user);
			Console.WriteLine("added "+user.Name+user.Email);
			return Ok(user);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string name)
		{
			UserModel user = users.FirstOrDefault(x => x.Name == name);
			if (user == null)
			{
				return NotFound();
			}
			users.Remove(user);
			return Ok(user);
		}

	}
}
