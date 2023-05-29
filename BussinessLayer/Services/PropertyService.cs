using AutoMapper;
using Housing_system.BussinessLayer.DTO;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;
using Housing_system.DataLayer.Repositories;
namespace Housing_system.BussinessLayer.Services
{ 
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            this._propertyRepository = propertyRepository;
            this._mapper = mapper;
        }

        public IEnumerable<PropertyDto> GetAllProperties()
        {
            var properties = _propertyRepository.GetAllProperties();
            var propertyDtos = _mapper.Map<IEnumerable<PropertyDto>>(properties);
            return propertyDtos;
        }

        public PropertyDto GetPropertyById(int id)
        {
            var property = _propertyRepository.GetPropertyById(id);
            var propertyDto = _mapper.Map<PropertyDto>(property);
            return propertyDto;
        }

        public PropertyDto CreateProperty(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            var createdProperty = _propertyRepository.CreateProperty(property);
            var createdPropertyDto = _mapper.Map<PropertyDto>(createdProperty);
            return createdPropertyDto;
        }

        public void DeleteProperty(int id)
        {
            var property = _propertyRepository.GetPropertyById(id);
            if (property == null)
            {
                throw new ApplicationException("Property not found.");
            }
            _propertyRepository.DeleteProperty(property);
        }
    }

}
