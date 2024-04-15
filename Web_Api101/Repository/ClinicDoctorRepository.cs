using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class ClinicDoctorRepository : IClinicDoctorRepository
    {

        private readonly DataContext _Context;
        public ClinicDoctorRepository(DataContext context)
        {
            _Context = context;
        }


        public ICollection<doctor_clinic> GetClinic_Doctors()
        {

            return _Context.doctor_Clinics.OrderBy(c => c.clinic_id).ToList();


        }
        public bool CreateClinicDoctor(doctor_clinic doctor_Clinic)
        {
            var clinicEntity = _Context.clinics.Where(o => o.Id == doctor_Clinic.clinic_id).FirstOrDefault();
            var doctorEntity = _Context.doctors.Where(c => c.id == doctor_Clinic.doctor_id).FirstOrDefault();
            var doctorHospital = new doctor_clinic()
            {
                 clinic= clinicEntity,
                doctor = doctorEntity

            };
            _Context.Add(doctorHospital);

            return Save();


        }

        public bool DeleteDoctor(doctor_clinic doctor_Clinic)
        {

            _Context.Remove(doctor_Clinic);
            return Save();

        }

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
