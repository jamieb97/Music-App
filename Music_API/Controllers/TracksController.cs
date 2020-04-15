﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_API.Models;

namespace Music_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly MusicDBContext _context;

        public TracksController(MusicDBContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTrack()
        {
            return await _context.Track.ToListAsync();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.Track.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        // PUT: api/Tracks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            if (id != track.TrackId)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Tracks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            _context.Track.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrack", new { id = track.TrackId }, track);
        }

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Track>> DeleteTrack(int id)
        {
            var track = await _context.Track.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Track.Remove(track);
            await _context.SaveChangesAsync();

            return track;
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.TrackId == id);
        }
    }
}
