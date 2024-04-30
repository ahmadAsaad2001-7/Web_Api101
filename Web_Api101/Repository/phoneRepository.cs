using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class phoneRepository : IphoneRepository
    {
        private readonly DataContext _context;
        public phoneRepository(DataContext context)
        {
            _context = context;
        }
        public bool Createphone(phones phones)
        {
            _context.Add(phones);
            return Save();
        }

        public bool deletephone(phones phones)
        {
            _context.Remove(phones);
            return Save();

        }

        public phones GetPhonebyId(int Id)
        {
            return _context.phones.Where(l => l.Id == Id).FirstOrDefault();

        }
        public ICollection<phones> GetPhonebydoctorId(int doctorId)
        {
            return _context.phones.Where(d => d.doctorId == doctorId).ToList();

        }
        public ICollection<phones> GetPhonebyhospitalId(int hospitalId)
        {
            return _context.phones.Where(d => d.hospitalId == hospitalId).ToList();

        }
        public ICollection<phones> GetPhonebyclinicId(int clinicId)
        {
            return _context.phones.Where(d => d.clinicId == clinicId).ToList();
        }


        public ICollection<phones> GetPhones()
        {
            return _context.phones.OrderBy(l => l.Id).ToList();
        }

        public bool phoneExist(int phoneId)
        {
            return _context.phones.Any(l => l.Id == phoneId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
