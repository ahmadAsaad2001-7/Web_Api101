using Web_Api101.Data;
using Web_Api101.Interface;
using Web_Api101.models;

namespace Web_Api102.Repository
{
    public class BurnRepository : IBurnsRepository
    {

        private readonly DataContext _Context;
        public BurnRepository(DataContext context) 
        {

            _Context = context;
        }
        public burns GetBurnById(int id)
        {
            return _Context.burns.Where(b => b.Id == id).FirstOrDefault();

         }
    }
}
