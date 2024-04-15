using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class Doctor_HospitalRepository : IDoctor_hospitalRepository
    {
        private readonly DataContext _Context;
        public Doctor_HospitalRepository(DataContext context)
        {
            _Context = context;
        }

        public bool CreateHospitalDoctor(hospital_doctor hospital_Doctor)
        {
            var hospitalEntity = _Context.hospitals.Where(o => o.id == hospital_Doctor.hospital_id).FirstOrDefault();
            var doctorEntity = _Context.doctors.Where(c => c.id == hospital_Doctor.doctor_id).FirstOrDefault();
            var doctorHospital = new hospital_doctor()
            {
                hospital = hospitalEntity,
                doctor = doctorEntity

            };
            _Context.Add(doctorHospital);

            return Save();
        }

        public bool DeleteDoctor(hospital_doctor hospital_Doctor)
        {

            _Context.Remove(hospital_Doctor);
            return Save();

        }

        public ICollection<hospital_doctor> GetHospital_Doctors()
        {
           
            return _Context.hospital_Doctors.OrderBy(c => c.hospital_id).ToList();


        }

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
