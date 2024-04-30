using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface IphoneRepository
    {
        ICollection<phones> GetPhones();
        phones GetPhonebyId(int Id);
        ICollection<phones> GetPhonebyclinicId(int clinicId);
        ICollection<phones> GetPhonebydoctorId(int doctorId);
        ICollection<phones> GetPhonebyhospitalId(int hospitalId);
      
        bool Createphone(phones phones);
        bool deletephone(phones phones);
        bool phoneExist(int phoneId);
        
        bool Save();



    }
}
