using Housing_system.DataLayer.Models;
using System.Runtime.ConstrainedExecution;

namespace Housing_system.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);

        User GetUserByEmail(string email);
        void Register(string username, string password,string email);

        User Authenticate(string  username,string password);
        void SaveChanges();
    }
}
