using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api101.Dto;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicDoctorController : ControllerBase
    {

        private readonly IClinicDoctorRepository _clinic_doctorRepository;
        private readonly IMapper _mapper;
        public ClinicDoctorController(IClinicDoctorRepository clinic_HospitalRepository, IMapper mapper)
        {
            _clinic_doctorRepository = clinic_HospitalRepository;
            _mapper = mapper;

        }

        //get
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<doctor_clinic>))]


        public IActionResult GetHospitalDoctors()
        {
            var doctors = _mapper.Map<List<clinic_DoctorDto>>(_clinic_doctorRepository.GetClinic_Doctors());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(doctors);

        }
        //create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Createclinic([FromBody] clinic_DoctorDto clnicdoctorsCreate)
        {
            if (clnicdoctorsCreate == null)
            {
                return BadRequest(ModelState);
            }


            var doctorsMap = _mapper.Map<doctor_clinic>(clnicdoctorsCreate);



            if (!_clinic_doctorRepository.CreateClinicDoctor(doctorsMap))
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

