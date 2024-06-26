﻿using AutoMapper;
using Web_Api101.Dto;
using Web_Api101.models;

namespace Web_Api101.helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<doctors, DoctorsDto>();
            CreateMap<DoctorsDto,doctors>();
            CreateMap<clinics, ClinicsDto>();
            CreateMap<ClinicsDto, clinics>();
            CreateMap<hospitals, HospitalDto>();
            CreateMap<HospitalDto, hospitals>();
            CreateMap<location, LocationDto>();
            CreateMap<LocationDto, location>();
            CreateMap<patient, PatientDto>();
            CreateMap<PatientDto, patient>();
            CreateMap<phones, PhonesDto>();
            CreateMap<PhonesDto, phones>();
            CreateMap<burns, BurnsDto>();
            CreateMap<BurnsDto, burns>();
            CreateMap<location, LocationDto>();
            CreateMap<LocationDto, location>();
            CreateMap<hospital_doctor, Hospital_DoctorDto>();
            CreateMap<Hospital_DoctorDto, hospital_doctor>();
            CreateMap<doctor_clinic, clinic_DoctorDto>();
            CreateMap<clinic_DoctorDto, doctor_clinic>();

        }
    }

}

