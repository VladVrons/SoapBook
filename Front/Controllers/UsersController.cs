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
				new UserModel("123") { Email = "soap@gmail.com", Name="Tyler", Tags="fight, smoke"},
				new UserModel("321") { Email = "ed.n@gmail.com", Name="Ed", Tags="fight, ikea"},
			};

		}

	
		[HttpGet]
		[Route("api/getname")]
		public UserModel Get()
		{
			
			UserModel user = new UserModel(userService.activeUser.Password)
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
			userService.activeUser = new (password) { Name = username, Email = email };
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

		[HttpPost]
		[Route("api/search")]
		public List<UserModel> Search(string substring)
		{
			List<UserModel> userList = new List<UserModel>();
			foreach(var user in users) 
			{
				if(user.Tags.Contains(substring) || (user.Name.Contains(substring)))
				{ userList.Add(user); }

			}
			return userList;
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
