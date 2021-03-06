﻿using System;
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
    public class AboutInfoesController : Controller
    {
        private readonly BlogDB _context;

        public AboutInfoesController(BlogDB context)
        {
            _context = context;
        }

        //Generated method
        [HttpGet]
        public IEnumerable<AboutInfo> GetAboutInfo()
        {
            return _context.AboutInfo;
        }

        //Generated method
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAboutInfo([FromRoute] int id, [FromBody] AboutInfo aboutInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aboutInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(aboutInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool AboutInfoExists(int id)
        {
            return _context.AboutInfo.Any(e => e.Id == id);
        }
    }
}