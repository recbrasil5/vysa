using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using VYSA.Domain.Concrete;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Models.ViewModel;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers {

    [RoutePrefix("Admin/Coaches")]
    public class AdminCoachesController : BaseAdminController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private CoachService coachService;
        public AdminCoachesController()
        {
            coachService = new CoachService(unitOfWork);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CoachResourceModel> GetCoaches()
        {
            return coachService.GetCoachResourceModels();
        }

        [HttpGet]
        [Route("GetCoachDropdownVms")]
        public IEnumerable<DropdownItemViewModel> GetCoachDropdownVms()
        {
            return coachService.GetCoachDropdownVMs();
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCoachById")]
        [ResponseType(typeof(CoachResourceModel))]
        public IHttpActionResult GetCoach(int id)
        {
            CoachResourceModel coach = coachService.GetCoach(id);

            // return it if you got it
            if (coach == null)
            {
                return NotFound();
            }

            return Ok(coach);
        }


        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(CoachResourceModel))]
        public IHttpActionResult UpdateCoach(int id, CoachResourceModel coachDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coachDto.Id)
            {
                return BadRequest();
            }

            var updatedCoachDTO = coachService.UpdateCoach(coachDto, User.Identity.Name);

            if (updatedCoachDTO == null)
            {
                //can't find the record to update
                return NotFound();
            }

            return Ok(updatedCoachDTO);
        }


        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CoachResourceModel))]
        public IHttpActionResult CreateCoach(CoachResourceModel coachDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCoachDTO = coachService.AddCoach(coachDto, User.Identity.Name);

            //for some reason this CreatedAtRoute doesn't work like it should for me - can't find GetCoachById
            //return CreatedAtRoute("GetCoachById", new { id = newCoachDTO.Id }, newCoachDTO);
            return Ok(newCoachDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(CoachResourceModel))]
        public IHttpActionResult DeleteCoach(int id)
        {
            var coach = coachService.SoftDeleteCoach(id, User.Identity.Name);
            if (coach == null)
            {
                return NotFound();
            }

            return Ok(coach);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }

}
