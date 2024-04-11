using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreatePatient(patient patient)
        {
            throw new NotImplementedException();
        }

        public bool DeletePatient(patient patient)
        {
            throw new NotImplementedException();
        }

        public patient GetPatient(int id)
        {
            return _context.patients.Where(p => p.Id == id).FirstOrDefault();

        }

        public patient GetPatientByPhone(string PhoneNumber)
        {
            return _context.patients.FirstOrDefault(p => p.Phones.Any(phone => phone.phone_number == PhoneNumber)); 
        }

        public ICollection<patient> GetPatients()
        {
            return _context.patients.OrderBy(o => o.Id).ToList();
            
        }

        public ICollection<patient> GetPatientsByBurnDegree(int burnId)
        {
            return _context.burn_Patients.Where(bp => bp.burn_id == burnId).Select(pc => pc.patient).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool UpdatePatient(patient patient)
        {
            _context.Update(patient);
            return Save();
        }
        public bool patientExist(string patient_name)
        {
            return _context.patients.Any(d => d.Name == patient_name);
        }
        public bool patientExist(int patientId)
        {
            return _context.patients.Any(d => d.Id == patientId);
        }

        ICollection<patient> IPatientRepository.GetPatientsByLocation(int id)
        {

            return _context.patients.Where(d => d.locid == id).ToList();


        }

    }
}
