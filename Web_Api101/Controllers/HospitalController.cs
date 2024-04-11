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
        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
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

    }
}
