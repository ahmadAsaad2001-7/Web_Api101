using AutoMapper;
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
    public class hospital_doctorController : ControllerBase
    {
        private readonly IDoctor_hospitalRepository _doctor_HospitalRepository;
        private readonly IMapper _mapper ;
        public hospital_doctorController(IDoctor_hospitalRepository doctor_HospitalRepository, IMapper mapper)
        { 
        _doctor_HospitalRepository= doctor_HospitalRepository;
            _mapper = mapper;

        }

        //get
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<hospital_doctor>))]

        
        public IActionResult GetHospitalDoctors ()
        {
            var doctors = _mapper.Map<List<Hospital_DoctorDto>>(_doctor_HospitalRepository.GetHospital_Doctors());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(doctors);

        }
        //create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDoctor( [FromBody] Hospital_DoctorDto hospitaldoctorsCreate)
        {
            if (hospitaldoctorsCreate == null)
            {
                return BadRequest(ModelState);
            }


            var doctorsMap = _mapper.Map<hospital_doctor>(hospitaldoctorsCreate);



            if (!_doctor_HospitalRepository.CreateHospitalDoctor(doctorsMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        //update
        //delete

    }
}
