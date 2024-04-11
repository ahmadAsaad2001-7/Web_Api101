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
    public class PatientController : ControllerBase
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
           mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<patient>))]

        public IActionResult GetPatients()
        {
            var patients = _mapper.Map<List<PatientDto>>(_patientRepository.GetPatients());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(patients);

        }

        [HttpGet("id")]
        [ProducesResponseType(200, Type = typeof(patient))]
        public IActionResult GetPatient(int id)
        {
            if (!_patientRepository.patientExist(id))
                return NotFound();

            var result = _mapper.Map<PatientDto>(_patientRepository.GetPatient(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(result);
        }
        [HttpGet("locationId")]
        [ProducesResponseType(200, Type = typeof(patient))]
        public IActionResult GetDoctorBylocation(int locationId)
        {
            var res = _mapper.Map<List<PatientDto>>(_patientRepository.GetPatientsByLocation(locationId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);
        }
        [HttpGet("BurnId")]
        [ProducesResponseType(200, Type = typeof(patient))]
        public IActionResult GetDoctorByBurnId(int BurnId)
        {


            var res = _mapper.Map<List<PatientDto>>(_patientRepository.GetPatientsByBurnDegree(BurnId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);
        }
    }
}
