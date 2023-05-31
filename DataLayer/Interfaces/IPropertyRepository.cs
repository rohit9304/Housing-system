using Housing_system.DataLayer.Models;

namespace Housing_system.DataLayer.Interfaces
{

        public interface IPropertyRepository
        {
            IEnumerable<Property> GetAllProperties();
            Property GetPropertyById(int id);
            Property CreateProperty(Property property);
            void DeleteProperty(Property property);
        }

}
