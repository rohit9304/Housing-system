using AutoMapper;
using Housing_system.BussinessLayer.DTO;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;
using Housing_system.DataLayer.Repositories;
using System;
using System.Security.Claims;
using System.Collections.Generic;

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
            try
            {
                var properties = _propertyRepository.GetAllProperties();
                var propertyDtos = _mapper.Map<IEnumerable<PropertyDto>>(properties);
                return propertyDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving properties.", ex);
            }
        }

        public PropertyDto GetPropertyById(int id)
        {
            try
            {
                var property = _propertyRepository.GetPropertyById(id);
                if (property == null)
                {
                    return null;
                }

                var propertyDto = new PropertyDto
                {
                    Id = property.Id,
                    Address = property.Address,
                    Price = property.Price,
                    Description = property.Description,
                    Bhk = property.Bhk,
                    CityId = property.CityId,
                    UserId = property.UserId
                };
                return propertyDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the property.", ex);
            }
        }

        public PropertyDto CreateProperty(PropertyDto propertyDto)
        {
            try
            {
                var property = _mapper.Map<Property>(propertyDto);
                var createdProperty = _propertyRepository.CreateProperty(property);
                var createdPropertyDto = _mapper.Map<PropertyDto>(createdProperty);
                return createdPropertyDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the property.", ex);
            }
        }

        public void DeleteProperty(int id)
        {
            try
            {
                var property = _propertyRepository.GetPropertyById(id);
                if (property == null)
                {
                    throw new ApplicationException("Property not found.");
                }
                _propertyRepository.DeleteProperty(property);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the property.", ex);
            }
        }
    }
}
