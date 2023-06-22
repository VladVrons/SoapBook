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
	public class SearchController : Controller
	{
		string searchMess = "1";

		static SearchController()
		{

		}


		[HttpGet]
		[Route("api/getanswer")]
		public Answ GetN()
		{
			Console.WriteLine("go it");
			Answ answ = new Answ()			
			{Mytxt = "zero", Myresponse = "ok" };
			return answ;
		}

		[HttpPost]
		[Route("api/writes")]
		public void SearchRes( string txt)
		{
			Console.WriteLine(txt);
			searchMess = txt;
		}
		
	}
	public class Answ
	{
		public string Mytxt;
		public string Myresponse;
		public Answ() { Mytxt = "zero"; }
	}
}





