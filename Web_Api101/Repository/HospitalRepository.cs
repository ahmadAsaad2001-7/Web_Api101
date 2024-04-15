using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class HospitalRepository : IHospitalRepository
    {

        private readonly DataContext _repository;
        public HospitalRepository(DataContext repository)
        {
            _repository = repository;
        }



        public bool CreateHospital( hospitals hospitals)
        {
            _repository.Add(hospitals);
            return Save();


        }

        public bool hospitalExist(int hospital_id)
        {

            return _repository.hospitals.Any(h => h.id == hospital_id);

        }

        public bool deleteHospital(hospitals hospital)
        {

            _repository.Remove(hospital);
            return Save();


        }

        public ICollection<hospitals> GetHospitals()
        {
            return _repository.hospitals.OrderBy(h=>h.id).ToList();



        }

        public ICollection<hospitals> GetHospitalsByLocationId(int location_id)
        {
            return _repository.hospitals.Where(h=>h.loc.id==location_id ).ToList() ;
        }

        public hospitals GetHospitalsByPhone(string PhoneNumber)
        {

            return _repository.hospitals.FirstOrDefault(hospital => hospital.Phones.Any(phone => phone.phone_number == PhoneNumber)); 
        }

        public ICollection<phones> GetPhonesByHospitalId(int id)
        {
            return _repository.phones.Where(p=>p.hospitals.id==id).ToList();
        }

        public bool HasHospital(string hospital_name)
        {
            return _repository.hospitals.Any(d => d.hospital_name == hospital_name);
        }
        public bool Save()
        {

            var saved = _repository.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateHospital(hospitals hospital)
        {
            _repository.Update(hospital);
            return Save();
        }
    }
}
