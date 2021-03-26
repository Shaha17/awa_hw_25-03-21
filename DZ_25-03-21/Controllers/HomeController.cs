using System.Threading;
using System.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DZ_25_03_21.Models;
using System.Data.SqlClient;
using Dapper;

namespace DZ_25_03_21.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly string _conStr = "Data source=10.211.55.3; initial catalog=AlifAcademy; user id=shaha; password=1234";

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var persons = new List<Person>();
			using (IDbConnection conn = new SqlConnection(_conStr))
			{
				persons = (await conn.QueryAsync<Person>("SELECT * FROM Persons")).ToList();
			}
			return View(persons);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
