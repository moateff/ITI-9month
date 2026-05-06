using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.shared.Models;

namespace task1.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TraineesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TraineesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/trainees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainee>>> GetTrainees()
        {
            return Ok(await _context.Trainees.Include(t => t.Track).ToListAsync());
        }

        // GET: api/trainees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainee>> GetTrainee(int id)
        {
            var trainee = await _context.Trainees
                .Include(t => t.Track)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainee == null)
                return NotFound();

            return Ok(trainee);
        }

        // POST: api/trainees
        [HttpPost]
        public async Task<ActionResult<Trainee>> CreateTrainee(Trainee trainee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trainees.Add(trainee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrainee), new { id = trainee.Id }, trainee);
        }

        // PUT: api/trainees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainee(int id, Trainee trainee)
        {
            if (id != trainee.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(trainee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/trainees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);

            if (trainee == null)
                return NotFound();

            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraineeExists(int id)
        {
            return _context.Trainees.Any(e => e.Id == id);
        }
    }
}