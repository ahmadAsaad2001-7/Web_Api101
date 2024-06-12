using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api101.Dto;
using Web_Api101.Interface;
using Web_Api101.models;
using Web_Api101.Repository;

namespace Web_Api101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class locationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public locationController(ILocationRepository locationRepository,IMapper mapper)
        {
            
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        //get
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<location>))]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetLocations() 
        {
            var locations = _mapper.Map<List<LocationDto>>(_locationRepository.GetLocations());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(locations);
        }

        [HttpGet("locationId")]
        [ProducesResponseType(200, Type = typeof(location))]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetCLinic(int locationId)
        {
            if (!_locationRepository.LocationExists(locationId))
                return NotFound();
            var res = _mapper.Map<LocationDto>(_locationRepository.GetLocation(locationId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);


        }
        //create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateClinic( [FromBody] LocationDto locationCreate)
        {
            if (locationCreate == null)
            {
                return BadRequest(ModelState);
            }

            var Pokemon = _locationRepository.GetLocations()
                .Where(o => o.id == locationCreate.id).FirstOrDefault();


            if (Pokemon != null)
            {
                ModelState.AddModelError("", "location already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var LocationMap = _mapper.Map<location>(locationCreate);


            
            if (!_locationRepository.CreateLocation(LocationMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        //delete


        [HttpDelete("{locationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDoctor(int locationId)
        {
            if (!_locationRepository.LocationExists(locationId))
                return NotFound();

            var locationToBeDeleted = _locationRepository.GetLocation(locationId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_locationRepository.DeleteLocation(locationToBeDeleted))
            {
                ModelState.AddModelError("", "something went wrong while deleting");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }

    }
}
