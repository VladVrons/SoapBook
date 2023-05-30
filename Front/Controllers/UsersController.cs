using FrontEnd.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SB.BLL.Service;
using System.Xml.Linq;

namespace FrontEnd.Controllers
{
	//[Route("api/[controller]")]
	public class UsersController : Controller	
	{
		//public UserService userService { get; set; }
		static readonly List<UserModel> users;
		static UserService userService = new UserService();
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
		[Route("api/getname")]
		public UserModel Get()
		{
			UserModel user = new UserModel("1111")
			{
				Name = userService.activeUser.Name,
				Email = userService.activeUser.Email,
				Tags = userService.activeUser.Tags
			};
			return user;
		}

		[HttpPost]
		[Route("api/login")]
		public void Login(string username, string password)
		{
			userService.activeUser.Name = username;
			Console.WriteLine(username);
		
		
		}
		[HttpPost]
		[Route("api/signup")]
		public ActionResult SignUp(string username, string password, string email)
		{
			users.Add(new UserModel(password) { Name = username, Email= email });
			Console.WriteLine(username+email);
			return Ok(email);

		}

		[HttpPost]
		[Route("api/edit")]
		public void Edit(string username,string email, string password, string tags)
		{
			userService.activeUser.Name = username;
			userService.activeUser.Email = email;
			userService.activeUser.Tags = tags;
			userService.activeUser.ChangePass(password);				
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
