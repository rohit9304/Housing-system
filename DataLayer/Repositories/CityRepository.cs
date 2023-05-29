using Housing_system.DataLayer.Data;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;

namespace Housing_system.DataLayer.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;

        public CityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public City GetCityById(int id)
        {
            var city = _dbContext.Cities.Find(id);
            if (city == null)
            {
                throw new InvalidOperationException($"City with ID {id} not found.");
            }
            return city;
        }


        public IEnumerable<City> GetAllCities()
        {
            return _dbContext.Cities.ToList();
        }
    }

}
