using Housing_system.DataLayer.Data;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;
using System.Security.Cryptography;

namespace Housing_system.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {id} not found.");
            }
            return user;
        }


        public User GetUserByUsername(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void Register(string userName, string password,string email)
        {

            User user = new User();
            user.Username = userName;
            user.Password = password;
            user.Email=email;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public User Authenticate(string username,string password)
        {   
            return _dbContext.Users.FirstOrDefault(x=>x.Username==username&&x.Password==password);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }

}
