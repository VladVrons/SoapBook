using FrontEnd.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
//using SB.BLL.Service;

namespace FrontEnd.Controllers
{
	//[Route("api/[controller]")]
	public class UsersController : Controller	
	{
		//public UserService userService { get; set; }
		static readonly List<UserModel> users;
		//public UserService userService;
		//public User user;
		
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
		[Route("api/login")]
		public void Login(string username, string password)
		{
			//users.Add(new UserModel(password) { Name = username});
			Console.WriteLine(username);
			//users.Add(user);
			//Console.WriteLine("added "+user.Name+user.Email);
			//return Ok(user);
		
		}
		[HttpPost]
		[Route("api/signup")]
		public void SignUp(string username, string password)
		{
			users.Add(new UserModel(password) { Name = username });
			Console.WriteLine(username);
			//users.Add(user);
			//Console.WriteLine("added "+user.Name+user.Email);
			//return Ok(user);

		}

		public class Person
		{
			public string name { get; set; }
			public string surname { get; set; }
		}

		public ActionResult Homepage()
		{
			
			return View();
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
