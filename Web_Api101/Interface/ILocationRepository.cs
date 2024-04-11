using Web_Api101.models;

namespace Web_Api101.Interface
{
    public interface ILocationRepository
    {
        ICollection<location> GetLocations();
        location GetLocation(int location_id);
        bool CreateLocation(location location);
        bool DeleteLocation(location location);
        bool UpdateLocation(location location);
        bool LocationExists(int location_id);
        bool Save();

    }
}
