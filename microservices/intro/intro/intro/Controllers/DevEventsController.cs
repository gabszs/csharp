using intro.Entities;
using intro.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace intro.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;
        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }


        // api/dev-events GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(o => !o.IsDeleted).ToList();

            return Ok(devEvents);
        }


        // api/dev-events/{Id} GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            var devEvent = _context.DevEvents.Include(de => de.Speakers).SingleOrDefault(d => d.Id == id);


            if (devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);
        }

        // api/dev-events POST
        [HttpPost]
        public IActionResult PostEvent(DevEvent devEvent) 
        {
            _context.DevEvents.Add(devEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        // api/dev-events/{Id} PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Update(input.Title,
                input.Description,
                input.StartDate,
                input.EndDate
                );

            _context.DevEvents.Update(devEvent);
            _context.SaveChanges();
            return NoContent();
        }



        // api/dev-events/{Id} DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            //var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == Id);
            DevEvent devEvent = _context.DevEvents.SingleOrDefault(o => o.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();

            _context.SaveChanges();

            return NoContent();
        }


        // api/dev-events/{id}/speakers
        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeakers(Guid id, DevEventSpeaker speaker)
        {
            speaker.DevEventId = id;
            var devEvent = _context.DevEvents.Any(d => d.Id == id);

            if (!devEvent)
            {
                return NotFound();
            }

            _context.DevEventSpeakers.Add(speaker);
            _context.SaveChanges(); 

            return NoContent();
        }  

    }
}
