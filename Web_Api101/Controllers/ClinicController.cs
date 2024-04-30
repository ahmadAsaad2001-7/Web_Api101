using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api101.Dto;
using Web_Api101.Interface;
using Web_Api101.Interface;
using Web_Api101.models;
using Web_Api101.Repository;

namespace Web_Api101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IDoctorRepository _doctorRepository;

        private readonly IMapper _mapper;
        public ClinicController(IClinicRepository clinicRepository, IMapper mapper, ILocationRepository locationRepository,IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _clinicRepository= clinicRepository  ;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }


        //get
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<clinics>))]

        public IActionResult GetClinics()
        {
            var clinic = _mapper.Map<List<ClinicsDto>>(_clinicRepository.GetClinics());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(clinic);

        }
        [HttpGet("clinicId")]
        [ProducesResponseType(200, Type = typeof(clinics))]
        public IActionResult GetCLinic(int clinicId)
        {
            if (!_clinicRepository.clinicExists(clinicId))
                return NotFound();
            var res = _mapper.Map<ClinicsDto>(_clinicRepository.GetClinicsById(clinicId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);


        }

        [HttpGet("doctorId")]
        [ProducesResponseType(200, Type = typeof(clinics))]
        public IActionResult GetCLinicBydoctor(int doctorId)
        {
            if (!_doctorRepository.DoctorExist(doctorId))
                return NotFound();
            var res = _clinicRepository.GetClinicsBydoctorId(doctorId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);


        }

        [HttpGet("locationId")]
        [ProducesResponseType(200, Type = typeof(clinics))]
        public IActionResult GetCLinicBylocation(int locationId)
        {
            if (!_doctorRepository.DoctorExist(locationId))
                return NotFound();
            var res = _clinicRepository.GetClinicsByLocation(locationId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);


        }

        //create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClinic([FromQuery] int locid, [FromQuery] int doctorId, [FromBody] ClinicsDto clinicCreate)
        {
            if (clinicCreate == null)
            {
                return BadRequest(ModelState);
            }

            var Pokemon = _clinicRepository.GetClinics()
                .Where(o => o.Id == clinicCreate.Id).FirstOrDefault();


            if (Pokemon != null)
            {
                ModelState.AddModelError("", "doctor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clinicMap = _mapper.Map<clinics>(clinicCreate);


            clinicMap.loc = _locationRepository.GetLocation(locid);

            if (!_clinicRepository.CreateClinic(doctorId, clinicMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
          
        }

        //delete

        [HttpDelete("{clinicId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDoctor(int clinicId)
        {
            if (!_clinicRepository.clinicExists(clinicId))
                return NotFound();

            var clinicToBeDeleted = _clinicRepository.GetClinicsById(clinicId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_clinicRepository.DeleteClinics(clinicToBeDeleted))
            {
                ModelState.AddModelError("", "something went wrong while deleting");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }



    }

}



 
