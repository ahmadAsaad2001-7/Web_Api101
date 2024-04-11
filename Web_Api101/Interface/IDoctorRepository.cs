using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IDoctorRepository
    {

        ICollection<doctors> GetDoctors();
        ICollection<doctors> GetDoctorsByHospitalId(int Hospital_id);
        doctors GetDoctors(int id);
        doctors GetDoctorsByPhone(string phoneNumber);
        ICollection<doctors> GetDoctorsByLocation_id(int location_id);
        bool DoctorExist(int doctorId);
        bool CreateDoctor(int hospitalId,int clinicId,doctors doctors);
        bool UpdateDoctor( doctors doctors);
        bool DeleteDoctor(doctors Doctor_id);
        bool Save();


    }
}
