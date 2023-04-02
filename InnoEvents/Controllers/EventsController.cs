using AutoMapper;
using InnoEvents.Infrastructure;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingParams pagingParams)
        {
            var dbEvents = await _unitOfWork.EventRepository.GetAllAsync(pagingParams.PageNumber, pagingParams.PageSize);                
            var events = _mapper.Map<IEnumerable<DTOs.Event>>(dbEvents);
            return Ok(events);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dbEvent = await _unitOfWork.EventRepository.SingleOrDefaultAsync(e => e.Id == id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.UserRepository.Get(dbEvent.ContactUserId);
            if (user == null)
            {
                return NotFound("Contact User not found");
            }

            var eventDto = _mapper.Map<DTOs.Event>(dbEvent);
            eventDto.ContactUser = user;

            return Ok(eventDto);
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTOs.CreateEvent ev)
        {
            var newEvent = _mapper.Map<Event>(ev);
            await _unitOfWork.EventRepository.AddAsync(newEvent);
            await _unitOfWork.EventRepository.SaveChangesAsync();
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

            var dbEvent = await _unitOfWork.EventRepository.SingleOrDefaultAsync(e => e.Id == id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            dbEvent.Name = ev.Name;

            try
            {
                await _unitOfWork.EventRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_unitOfWork.EventRepository.Exists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dbEvent = await _unitOfWork.EventRepository.SingleOrDefaultAsync(e => e.Id == id);
            if (dbEvent == null)
            {
                return NotFound();
            }

            _unitOfWork.EventRepository.Remove(dbEvent);
            return NoContent();
        }

        // GET: api/<EventsController>/5/users
        [HttpGet("{id}/users")]
        public async Task<IActionResult> GetAllUsers(int id, [FromQuery] PagingParams pagingParams)
        {
            var dbEvents = await _unitOfWork.EventUserRepository.GetAllAsync(ue => ue.EventId == id, pagingParams.PageNumber, pagingParams.PageSize);                
            var events = _mapper.Map<IEnumerable<DTOs.Event>>(dbEvents);
            return Ok(events);
        }

        // POST api/<EventsController>/5/users/6
        [HttpPost("{eventId}/users/{userId}")]
        public async Task<IActionResult> RegisterEvent(int userId, int eventId)
        {
            var alreadyRegistered = await _unitOfWork.EventUserRepository.ExistsAsync(eventId, userId);
            if (alreadyRegistered)
            {
                return Conflict("User already registered to this event.");
            }

            var user = await _unitOfWork.UserRepository.Get(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var dbEvent = await _unitOfWork.EventRepository.SingleOrDefaultAsync(e => e.Id == eventId);
            if (dbEvent == null)
            {
                return NotFound("Event not found");
            }

            var ue = new UserEvent { UserId = userId, EventId = eventId };
            await _unitOfWork.EventUserRepository.AddAsync(ue);
            await _unitOfWork.EventUserRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllUsers), new { id = ue.EventId }, user);
        }

        // DELETE api/<EventsController>/5/users/6
        [HttpDelete("{eventId}/users/{userId}")]
        public async Task<IActionResult> UnregisterEvent(int userId, int eventId)
        {
            var alreadyRegistered = await _unitOfWork.EventUserRepository.SingleOrDefaultAsync(ue => ue.UserId == userId && ue.EventId == eventId);
            if (alreadyRegistered == null)
            {
                return Conflict("User is not registered to this event.");
            }

            _unitOfWork.EventUserRepository.Remove(alreadyRegistered);
            return NoContent();
        }
    }
}
