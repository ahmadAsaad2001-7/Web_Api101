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
    public class PhoneController : ControllerBase
    {
        private readonly IphoneRepository _phoneRepository;
        private readonly IMapper _mapper;

        public PhoneController(IphoneRepository iphoneRepository, IMapper mapper)
        {
       
            _phoneRepository = iphoneRepository;
            _mapper = mapper;
            
        }
        //get
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<phones>))]
        public IActionResult Getphones()
        {
            var locations = _mapper.Map<List<PhonesDto>>(_phoneRepository.GetPhones());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(locations);
        }

        [HttpGet("phoneId")]
        [ProducesResponseType(200, Type = typeof(phones))]
        public IActionResult GetPhoneById(int phoneId)
        {
            if (!_phoneRepository.phoneExist(phoneId))
                return NotFound();
            var res = _mapper.Map<LocationDto>(_phoneRepository.GetPhonebyId(phoneId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);


        }
        [HttpGet("hospitalId")]
        [ProducesResponseType(200, Type = typeof(phones))]
        public IActionResult GetPhoneByHospital(int hospitalId)
        {
            var res = _mapper.Map<List<PhonesDto>>(_phoneRepository.GetPhonebyhospitalId(hospitalId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(res);
        }
        [HttpGet("doctorId")]
        [ProducesResponseType(200, Type = typeof(phones))]
        public IActionResult GetPhoneByDoctor(int doctorId)
        {
            var res = _mapper.Map<List<PhonesDto>>(_phoneRepository.GetPhonebydoctorId(doctorId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(res);
        }


        //create

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClinic([FromBody] PhonesDto phonesCreate)
        {
            if (phonesCreate == null)
            {
                return BadRequest(ModelState);
            }

            var Pokemon = _phoneRepository.GetPhones()
                .Where(o => o.Id == phonesCreate.Id).FirstOrDefault();


            if (Pokemon != null)
            {
                ModelState.AddModelError("", "location already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phonesMap = _mapper.Map<phones>(phonesCreate);



            if (!_phoneRepository.Createphone(phonesMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        //delete
        [HttpDelete("{phoneId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDoctor(int phoneId)
        {
            if (!_phoneRepository.phoneExist(phoneId))
                return NotFound();

            var phoneToBeDeleted = _phoneRepository.GetPhonebyId(phoneId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_phoneRepository.deletephone(phoneToBeDeleted))
            {
                ModelState.AddModelError("", "something went wrong while deleting");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }




    }
}
