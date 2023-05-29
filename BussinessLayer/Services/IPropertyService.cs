using Housing_system.BussinessLayer.DTO;

namespace Housing_system.BussinessLayer.Services
{
    public interface IPropertyService
    {
        IEnumerable<PropertyDto> GetAllProperties();
        PropertyDto GetPropertyById(int id);
        PropertyDto CreateProperty(PropertyDto propertyDto);
        void DeleteProperty(int id);
    }
}
