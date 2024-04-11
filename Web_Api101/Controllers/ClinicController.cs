﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public ClinicController(IClinicRepository clinicRepository, IMapper mapper, ILocationRepository locationRepository)
        {
            clinicRepository = _clinicRepository;
            _mapper = mapper;
            _locationRepository = locationRepository;
        }


        //get
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<clinics>))]

        public IActionResult GetDoctors()
        {
            var doctors = _mapper.Map<List<ClinicsDto>>(_clinicRepository.GetClinics());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(doctors);

        }
        [HttpGet("clinicId")]
        [ProducesResponseType(200, Type = typeof(clinics))]
        public IActionResult GetDoctor(int clinicId)
        {
            if (!_clinicRepository.clinicExists(clinicId))
                return NotFound();
            var res = _mapper.Map<DoctorsDto>(_clinicRepository.GetClinicsById(clinicId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(res);


        }

        [HttpGet("phoneNumber")]
        [ProducesResponseType(200, Type = typeof(clinics))]
        public IActionResult GetDoctorByPhone(string phoneNumber)
        {
            var res = _mapper.Map<List<DoctorsDto>>(_clinicRepository.GetClinicsByPhone(phoneNumber));
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



    }

}



 
