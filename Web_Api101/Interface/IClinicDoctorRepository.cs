using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IClinicDoctorRepository
    {
        ICollection<doctor_clinic> GetClinic_Doctors();

        bool CreateClinicDoctor(doctor_clinic doctor_Clinic);
        bool DeleteDoctor(doctor_clinic doctor_Clinic);
        bool Save();

    }
}
