using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IHospitalRepository
    {
      public  ICollection<hospitals> GetHospitals();
      public   ICollection<hospitals> GetHospitalsByLocationId(int location_id);
      public  ICollection<phones> GetPhonesByHospitalId(int id);
       public hospitals GetHospitalsByPhone(string PhoneNumber);
         public bool HasHospital(string hospital_name);
        public bool CreateHospital( hospitals hospitals);
         public bool UpdateHospital(hospitals hospital);
         public bool deleteHospital(hospitals hospital);
        public bool hospitalExist(int hospital_id);
         public bool Save();




    }
}
