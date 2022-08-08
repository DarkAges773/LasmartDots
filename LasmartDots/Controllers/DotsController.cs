using LasmartDots.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasmartDots.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class DotsController : ControllerBase
	{
		private ApplicationContext db;
		public DotsController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dot>>> Get()
		{
			var result = await db.Dots.Include(d => d.Comments).ToListAsync();
			return result;
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Dot>> Get(int id)
		{
			Dot dot = await db.Dots.Include(d => d.Comments).FirstOrDefaultAsync(x => x.Id == id);
			if (dot == null)
				return NotFound();
			return new ObjectResult(dot);
		}
		[HttpPost]
		public async Task<ActionResult<Dot>> Post(Dot dot)
		{
			if (dot == null)
			{
				return BadRequest();
			}

			db.Dots.Add(dot);
			await db.SaveChangesAsync();
			return Ok(dot);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Dot>> Delete(int id)
		{
			Dot dot = db.Dots.FirstOrDefault(x => x.Id == id);
			if (dot == null)
			{
				return NotFound();
			}
			db.Dots.Remove(dot);
			await db.SaveChangesAsync();
			return Ok(dot);
		}
	}
}
