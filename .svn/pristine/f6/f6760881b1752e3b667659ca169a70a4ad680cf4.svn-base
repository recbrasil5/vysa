using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VYSA.Domain.Concrete;
using VYSA.WebApi.Filters;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [RoutePrefix("Admin/Events")]
    public class AdminEventsController : BaseAdminController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EventService eventService;
        public AdminEventsController()
        {
            eventService = new EventService(unitOfWork);
        }

        [HttpGet]
        [Route("GetEventsBySeasonId/{seasonId:int}", Name = "GetEventsBySeasonId")]
        [ResponseType(typeof(IEnumerable<EventListViewSimpleResourceModel>))]
        public IEnumerable<EventListViewSimpleResourceModel> GetEventsBySeasonId(int seasonId) //webApi hybrid call
        {
            return eventService.GetEventListViewSimpleDtos(seasonId);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetEventById")]
        [ResponseType(typeof(EventResourceModel))]
        public IHttpActionResult GetEvent(int id)
        {
            var Event = eventService.GetEvent(id);

            // return it if you got it
            if (Event == null)
            {
                return NotFound();
            }

            return Ok(Event);
        }



        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(EventResourceModel))]
        public IHttpActionResult UpdateEvent(int id, EventResourceModel EventDTO)
        {
            if (id != EventDTO.Id)
            {
                return BadRequest();
            }

            var updatedEventDTO = eventService.UpdateEvent(EventDTO, User.Identity.Name);

            if (updatedEventDTO == null)
            {
                //can't find the record to update
                return NotFound();
            }

            return Ok(updatedEventDTO);
        }


        [HttpPost]
        [Route("")]
        [ResponseType(typeof(EventResourceModel))]
        public IHttpActionResult CreateEvent(EventResourceModel EventDTO)
        {
            var newEventDTO = eventService.AddEvent(EventDTO, User.Identity.Name);

            //for some reason this CreatedAtRoute doesn't work like it should for me - can't find GetEventById
            //return CreatedAtRoute("GetEventById", new { id = newEventDTO.Id }, newEventDTO);
            return Ok(newEventDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(EventResourceModel))]
        public IHttpActionResult DeleteEvent(int id)
        {
            var Event = eventService.SoftDeleteEvent(id, User.Identity.Name);
            if (Event == null)
            {
                return NotFound();
            }

            return Ok(Event);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
