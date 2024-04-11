using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IClinicRepository
    {
        ICollection<clinics> GetClinics();
        ICollection<clinics> GetClinicsByLocation(int city_id);
        public ICollection<clinics> GetClinicsBydoctorId(int doctor_id);
        clinics GetClinicsById(int id);
        clinics GetClinicsByPhone(string Phone);
        bool clinicExists(int id);
        bool CreateClinic(int doctorid, clinics clinic);
        bool UpdateClinics(clinics clinics);
        bool DeleteClinics(int id);
        bool Save();




    }
}
