using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_F18.Models;
using Newtonsoft.Json;
using System.IO;

namespace IT_F18.Controllers
{
    [Route("api/[controller]")]
    public class GalleryEntriesController : Controller
    {
        private readonly BlogDB _context;

        public GalleryEntriesController(BlogDB context)
        {
            _context = context;
        }

        //Generated method
        [HttpGet]
        public IEnumerable<GalleryEntry> GetGalleryEntry()
        {
            return _context.GalleryEntry;
        }

        //Generated method
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGalleryEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var galleryEntry = await _context.GalleryEntry.SingleOrDefaultAsync(m => m.Id == id);

            if (galleryEntry == null)
            {
                return NotFound();
            }

            return Ok(galleryEntry);
        }

        //Generated method
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryEntry([FromRoute] int id, [FromBody] GalleryEntry galleryEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != galleryEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(galleryEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryEntryExists(id))
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

        //Customized method
        [HttpPost]
        public async Task<IActionResult> PostGalleryEntry()
        {
            //As both a file and info on the GalleryEntry come together
            //the default parser using [FromBody] caused issues, so
            //Instead it is done manually, there may be better/automtic
            //ways of doing this.

            GalleryEntry galleryEntry = (GalleryEntry)JsonConvert.DeserializeObject(Request.Form["json"], typeof(GalleryEntry));

            //Get the file from the request and saves it in the wwwroot folder
            var file = Request.Form.Files[0];
            var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot",file.FileName);
            galleryEntry.ImagePath = "/" + file.FileName;

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //The rest is generated code
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.GalleryEntry.Add(galleryEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGalleryEntry", new { id = galleryEntry.Id }, galleryEntry);
        }

        //Generated method
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var galleryEntry = await _context.GalleryEntry.SingleOrDefaultAsync(m => m.Id == id);
            if (galleryEntry == null)
            {
                return NotFound();
            }

            _context.GalleryEntry.Remove(galleryEntry);
            await _context.SaveChangesAsync();

            return Ok(galleryEntry);
        }

        private bool GalleryEntryExists(int id)
        {
            return _context.GalleryEntry.Any(e => e.Id == id);
        }
    }
}