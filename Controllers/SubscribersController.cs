using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_F18.Models;

namespace IT_F18.Controllers
{
    [Route("api/[controller]")]
    public class SubscribersController : Controller
    {
        private readonly BlogDB _context;

        public SubscribersController(BlogDB context)
        {
            _context = context;
        }

        // GET: api/Subscribers
        [HttpGet]
        public IEnumerable<Subscriber> GetSubscriber()
        {
            return _context.Subscriber;
        }

        // POST: api/Subscribers
        [HttpPost]
        public async Task<IActionResult> PostSubscriber([FromBody] Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subscriber.Add(subscriber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriber", new { id = subscriber.Id }, subscriber);
        }

        // DELETE: api/Subscribers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriber = await _context.Subscriber.SingleOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            _context.Subscriber.Remove(subscriber);
            await _context.SaveChangesAsync();

            return Ok(subscriber);
        }
    }
}