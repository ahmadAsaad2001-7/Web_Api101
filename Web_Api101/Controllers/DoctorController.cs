using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api101.Interface;
using Web_Api101.models;
using Web_Api101.Interface;
using Web_Api101.models;
using AutoMapper;
using Web_Api101.Dto;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Web_Api101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;

        }
        //get
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<doctors>))]

        public IActionResult GetDoctors() 
        {
            var doctors =_mapper.Map<List<DoctorsDto>>(_doctorRepository.GetDoctors());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(doctors);

        }
        [HttpGet("doctorId")]
        [ProducesResponseType(200, Type = typeof(doctors))]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetDoctor(int doctorId)
        {
            if (!_doctorRepository.DoctorExist(doctorId)) 
        return NotFound();
            var res= _mapper.Map <DoctorsDto> (_doctorRepository.GetDoctors(doctorId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
       
            return Ok(res);

               
        }

        [HttpGet("locationId")]
        [ProducesResponseType(200, Type = typeof(doctors))]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetDoctorBylocation(int locationId)
        {
            var res = _mapper.Map < List < DoctorsDto >> (_doctorRepository.GetDoctorsByLocation_id(locationId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(res);
        }

        [HttpGet("hospitalId")]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(200, Type = typeof(doctors))]
        public IActionResult GetDoctorByhospital(int hospitalId)
        {
            var res = _mapper.Map<List<DoctorsDto>>(_doctorRepository.GetDoctorsByHospitalId(hospitalId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(res);
        }

        [HttpGet("phoneNumber")]
        [Authorize(Roles = "User,Admin")]
        [ProducesResponseType(200, Type = typeof(doctors))]
        public IActionResult GetDoctorByPhone(string phoneNumber)
        {
            var res = _mapper.Map<DoctorsDto>(_doctorRepository.GetDoctorsByPhone(phoneNumber));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);
        }


        //delete
        [HttpDelete("{doctorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            if (!_doctorRepository.DoctorExist(doctorId))
                return NotFound();

            var doctorToBeDeleted = _doctorRepository.GetDoctors(doctorId);
            if (!ModelState.IsValid)
            { 
            return BadRequest(ModelState);
            }
            if (!_doctorRepository.DeleteDoctor(doctorToBeDeleted))
            {
                ModelState.AddModelError("", "something went wrong while deleting");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }


        //update

        [HttpPut("{doctorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateOwner(int doctorId, [FromQuery] int ClinicId, [FromQuery] int hospitalId, [FromBody] DoctorsDto updatedDoctor)
        {
            if (updatedDoctor == null)
                return BadRequest(ModelState);

            if (doctorId != updatedDoctor.id)
                return BadRequest(ModelState);

            if (!_doctorRepository.DoctorExist(doctorId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var doctorMap = _mapper.Map<doctors>(updatedDoctor);

            if (!_doctorRepository.UpdateDoctor(  doctorMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateDoctor([FromQuery] int ClinicId, [FromQuery] int hospitalId, [FromBody] DoctorsDto doctorsCreate)
        {
            if (doctorsCreate == null)
            {
                return BadRequest(ModelState);
            }

            var Pokemon = _doctorRepository.GetDoctors()
                .Where(o => o.name.Trim().ToLower() == doctorsCreate.name.TrimEnd().ToLower()).FirstOrDefault();


            if (Pokemon != null)
            {
                ModelState.AddModelError("", "doctor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doctorsMap = _mapper.Map<doctors>(doctorsCreate);



            if (!_doctorRepository.CreateDoctor(ClinicId, hospitalId, doctorsMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }



    }

}
