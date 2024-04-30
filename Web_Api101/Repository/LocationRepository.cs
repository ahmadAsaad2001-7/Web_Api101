using Microsoft.EntityFrameworkCore;
using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api101.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _context;
        public LocationRepository(DataContext context) {
        _context = context;
        }
        public bool CreateLocation(location location)
        {
            _context.Add(location);
            return Save();
        }

        public bool DeleteLocation(location c)
        {
            _context.Remove(c);
            return Save();



        }

        public location GetLocation(int location_id)
        {
            return _context.locations.Where(l => l.id == location_id).FirstOrDefault();

        }

        public ICollection<location> GetLocations()
        {
            return _context.locations.OrderBy(l => l.id).ToList();
            
        }

        public bool LocationExists(int location_id)
        {
            return _context.locations.Any(l=> l.id == location_id);
        }

        public bool Save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLocation(location location)
        {
            _context.Update(location);
            return Save();
        }
    }
}
