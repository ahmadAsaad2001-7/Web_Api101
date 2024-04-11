using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IPatientRepository
    {
        ICollection<patient> GetPatients();
        ICollection<patient> GetPatientsByLocation(int id);
        ICollection<patient> GetPatientsByBurnDegree(int burnId);

        patient GetPatient(int id);
        patient GetPatientByPhone(string PhoneNumber);
        bool CreatePatient(patient patient);
        bool DeletePatient(patient patient);
        bool UpdatePatient(patient patient);
        public bool patientExist(string patient_name);
        public bool patientExist(int id);
         
        bool Save();


    }
}
