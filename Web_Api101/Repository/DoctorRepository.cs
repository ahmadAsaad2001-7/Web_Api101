using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly DataContext _Context;
        public DoctorRepository(DataContext dataContext) 
        { _Context = dataContext; }

        public bool CreateDoctor(int hospitalId, int clinicId, doctors doctors)
        {
            var doctorhospitalEntity = _Context.hospitals.Where(o => o.id == hospitalId).FirstOrDefault();
            var doctorClinicEntity = _Context.clinics.Where(c => c.Id == clinicId).FirstOrDefault();
            var doctorHospital = new hospital_doctor()
            {hospital=doctorhospitalEntity,
            doctor=doctors

            };
            _Context.Add(doctorHospital);
            var doctorClinic = new doctor_clinic()
            {
                doctor = doctors,
                clinic = doctorClinicEntity
            };

            _Context.Add(doctorClinic);
            _Context.Add(doctors);
            return Save();


        }

        public bool DeleteDoctor(doctors Doctor)
        {
            _Context.Remove(Doctor);
            return Save();

        }

        public bool DoctorExist(int doctorId)
        {

            return _Context.doctors.Any(d => d.id == doctorId);

        }

        public ICollection<doctors> GetDoctors()
        {
            return _Context.doctors.OrderBy(d=>d.id).ToList();
        }

        public doctors GetDoctors(int id)
        {
            return _Context.doctors.Where(d => d.id == id).FirstOrDefault();
        }

        public ICollection<doctors> GetDoctorsByHospitalId(int Hospital_id)
        {
        return _Context.hospital_Doctors.Where(hd=>hd.hospital_id==Hospital_id).Select(hd=>hd.doctor).ToList();
        }

        public ICollection<doctors> GetDoctorsByLocation_id(int location_id)
        {
            return _Context.doctors.Where(d=>d.LocationId==location_id).ToList();
        }

        public doctors GetDoctorsByPhone(string phoneNumber)
        {
            return _Context.doctors.FirstOrDefault(d => d.phones.Any(p => p.phone_number == phoneNumber));
        }

        public bool UpdateDoctor( doctors doctors)
        {
            _Context.Update(doctors);
            return Save();
        }

        public bool doctorExist(int doctor_id) 
        {
            return _Context.doctors.Any(d => d.id == doctor_id);
        }

        public bool doctorExist(string doctor_name)
        {
            return _Context.doctors.Any(d => d.name == doctor_name);
        }
        public bool Save()
        {

            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
