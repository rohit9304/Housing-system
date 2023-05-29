using Housing_system.DataLayer.Data;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Housing_system.DataLayer.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _context;

        public PropertyRepository(AppDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.Properties.Include(p => p.City).Include(p => p.User).ToList();
        }


        public Property GetPropertyById(int id)
        {
            return _context.Properties
                .Where(p => p.Id == id)
                .Include(p => p.City)
                .Include(p => p.User)
                .FirstOrDefault();
        }

        public Property CreateProperty(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public void DeleteProperty(Property property)
        {
            _context.Properties.Remove(property);
            _context.SaveChanges();
        }
    }

}
