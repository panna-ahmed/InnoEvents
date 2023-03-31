using AutoMapper;
using InnoEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InnoEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly InnoContext _context;
        private readonly IMapper _mapper;

        public EventsController(InnoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dbEvents = await _context.Events.ToListAsync();
            var events = _mapper.Map<IEnumerable<DTOs.Event>>(dbEvents);
            return Ok(events);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dbEvent = await _context.Events.SingleOrDefaultAsync(e => e.Id == id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            var eventDto = _mapper.Map<IEnumerable<DTOs.Event>>(dbEvent);
            return Ok(eventDto);
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOs.Event ev)
        {
            ev.Id = 0;
            var newEvent = _mapper.Map<Event>(ev);
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = newEvent.Id }, newEvent);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DTOs.Event ev)
        {
            if (id != ev.Id)
            {
                return BadRequest();
            }

            var dbEvent = await _context.Events.FindAsync(id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            dbEvent.Name = ev.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EventExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dbEvent = await _context.Events.FindAsync(id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(dbEvent);
            return NoContent();
        }

        // POST api/<EventsController>/5/users/6
        [HttpPost("{eventId}/users/{userId}")]
        public async Task<IActionResult> RegisterEvent(int userId, int eventId)
        {
            var alreadyRegistered = await _context.UserEvents.AnyAsync(ue => ue.UserId == userId && ue.EventId == eventId);
            if (alreadyRegistered)
            {
                return Conflict("User already registered to this event.");
            }

            var dbUser = await _context.Users.FindAsync(userId);
            if (dbUser == null)
            {
                return NotFound("User not found");
            }

            var dbEvent = await _context.Events.FindAsync(eventId);
            if (dbEvent == null)
            {
                return NotFound("Event not found");
            }

            var ue = new UserEvent { UserId = userId, EventId = eventId };
            _context.UserEvents.Add(ue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(UsersController.GetAllEvents), nameof(UsersController), new { id = userId });
        }

        // DELETE api/<EventsController>/5/users/6
        [HttpDelete("{eventId}/users/{userId}")]
        public async Task<IActionResult> UnregisterEvent(int userId, int eventId)
        {
            var alreadyRegistered = await _context.UserEvents.SingleOrDefaultAsync(ue => ue.UserId == userId && ue.EventId == eventId);
            if (alreadyRegistered == null)
            {
                return Conflict("User is not registered to this event.");
            }

            _context.UserEvents.Remove(alreadyRegistered);
            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
