using AutoMapper;
using InnoEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InnoEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InnoContext _context;
        private readonly IMapper _mapper;

        public UsersController(InnoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<UsersController>/5/events
        [HttpGet("{id}/events")]
        public async Task<IActionResult> GetAllEvents(int id)
        {
            var dbEvents = await _context.UserEvents.Where(ue => ue.UserId == id).Select(ue => ue.Event).ToListAsync();
            var events = _mapper.Map<IEnumerable<DTOs.Event>>(dbEvents);
            return Ok(events);
        }    
    }
}
