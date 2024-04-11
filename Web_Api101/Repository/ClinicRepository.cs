using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly DataContext _Context;
        public ClinicRepository(DataContext context)
        {
            _Context = context;
        }
        public bool CreateClinic( int doctorid, clinics clinic)
        {
            var clinicDoctorEntity = _Context.doctors.Where(o => o.id == doctorid).FirstOrDefault();
            var ClinicDoctor = new doctor_clinic()
            {
                doctor = clinicDoctorEntity,
                clinic = clinic

            };
            _Context.Add(ClinicDoctor);
            

            _Context.Add(ClinicDoctor);
            _Context.Add(clinic);
            return Save();


        }

        public bool DeleteClinics(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<clinics> GetClinics()
        {
            return _Context.clinics.OrderBy(c => c.Id).ToList();
        }

        public clinics GetClinicsById(int id)
        {
            return _Context.clinics.Where(c => c.Id == id).FirstOrDefault();
        
        }

        public ICollection<clinics> GetClinicsByLocation(int city_id)
        {
            return _Context.clinics.Where(h => h.loc.id == city_id).ToList();
        }
        public ICollection<clinics> GetClinicsBydoctorId(int doctor_id)
        {
            return _Context.clinics.Where(h => h.doctor_Clinics.Any(d=>d.doctor_id == doctor_id) ).ToList();
        }

        public bool Save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;

        }
        public bool UpdateClinics(clinics clinics)
        {
            _Context.Update(clinics);
            return Save();
        }

        public bool  clinicExists(int id)
        {
            return _Context.clinics.Any(d => d.Id == id);

        }

       public  clinics GetClinicsByPhone(string phone_number)
        {
            return _Context.clinics.FirstOrDefault(d => d.Phones.Any(p => p.phone_number == phone_number));
        }
    }
}
