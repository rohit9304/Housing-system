using Housing_system.DataLayer.Models;

namespace Housing_system.DataLayer.Interfaces
{
    public interface ICityRepository
    {
        City GetCityById(int id);
        IEnumerable<City> GetAllCities();
    }

}
