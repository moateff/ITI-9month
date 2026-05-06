using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.shared.Models;

namespace task1.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TracksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return Ok(await _context.Tracks.ToListAsync());
        }

        // GET: api/tracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
                return NotFound();

            return Ok(track);
        }

        // POST: api/tracks
        [HttpPost]
        public async Task<ActionResult<Track>> CreateTrack(Track track)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrack), new { id = track.Id }, track);
        }

        // PUT: api/tracks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrack(int id, Track track)
        {
            if (id != track.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/tracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
                return NotFound();

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.Id == id);
        }
    }
}