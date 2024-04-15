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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;
        public HospitalController(IHospitalRepository hospitalRepository,IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HospitalDto>))]

        public IActionResult GetHospitals()
        {
        var res =_hospitalRepository.GetHospitals();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res); 
        }

        [HttpGet("locationId")]
        [ProducesResponseType(200, Type = typeof(hospitals))]
        public IActionResult GetHospitalBylocation(int locationId)
        {
            var res = (_hospitalRepository.GetHospitalsByLocationId(locationId));

            return Ok(res);
        }

        [HttpGet("HospitalPhone")]
        [ProducesResponseType(200, Type = typeof(hospitals))]
        public IActionResult GetHospitalByPhone(string HospitalPhone)
        {
            var res = (_hospitalRepository.GetHospitalsByPhone(HospitalPhone));

            return Ok(res);
        }
        //Create
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDoctor(  [FromBody] HospitalDto hospitalCreate)
        {
            if (hospitalCreate == null)
            {
                return BadRequest(ModelState);
            }

            var Pokemon = _hospitalRepository.GetHospitals()
                .Where(o => o.hospital_name.Trim().ToLower() == hospitalCreate.hospital_name.TrimEnd().ToLower()).FirstOrDefault();


            if (Pokemon != null)
            {
                ModelState.AddModelError("", "doctor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hospitalsMap = _mapper.Map<hospitals>(hospitalCreate);



            if (!_hospitalRepository.CreateHospital( hospitalsMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

    }
}
