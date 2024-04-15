using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IDoctor_hospitalRepository
    {
        ICollection<hospital_doctor> GetHospital_Doctors();
        bool CreateHospitalDoctor(hospital_doctor hospital_Doctor);
        bool DeleteDoctor(hospital_doctor hospital_Doctor);
        bool Save();



    }
}
