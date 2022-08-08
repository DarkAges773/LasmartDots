using LasmartDots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LasmartDots.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationContext db;
		public HomeController(ApplicationContext context)
		{
			db = context;
		}
		[Route("/")]
		public async Task<IActionResult> Index()
		{
			return View(await db.Dots.Include(d => d.Comments).ToListAsync());
		}
		[Route("/Create")]
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[Route("/Create")]
		[HttpPost]
		public async Task<IActionResult> Create(Dot dot)
		{
			db.Dots.Add(dot);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}		
		[Route("/Comment")]
		[HttpGet]
		public async Task<IActionResult> Comment()
		{
			ViewBag.Dots = await db.Dots.ToListAsync();
			return View();
		}
		[Route("/Comment")]
		[HttpPost]
		public async Task<IActionResult> Comment(Comment comment)
		{
			db.Comments.Add(comment);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[Route("/Privacy")]
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
