using Housing_system.BussinessLayer.DTO;

namespace Housing_system.BussinessLayer.Services
{
    public interface IUserService
    {
        string AuthenticateUser(UserLoginDto loginDto);
        void RegisterUser(UserRegistrationDto registrationDto);
    }

}
