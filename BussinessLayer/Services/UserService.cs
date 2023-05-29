using Housing_system.BussinessLayer.DTO;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Housing_system.BussinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public void RegisterUser(UserRegistrationDto registrationDto)
        {
            // Check if username is already taken
            if (_userRepository.GetUserByUsername(registrationDto.Username) != null)
            {
                throw new ApplicationException("Username is already taken");
            }

            // Check if email is already used
            if (_userRepository.GetUserByEmail(registrationDto.Email) != null)
            {
                throw new ApplicationException("Email is already used");
            }


            _userRepository.Register(registrationDto.Username,registrationDto.Password,registrationDto.Email);
            _userRepository.SaveChanges();
        }
        public string AuthenticateUser(UserLoginDto loginDto)
        {
            var user = _userRepository.Authenticate(loginDto.Username,loginDto.Password);

            // Check if user exists and password is correct
            if (user == null )
            {
                throw new Exception("Invalid username or password."); 
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);

            return token;
        }

        

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       // private bool VerifyPassword(string storedHash, string password)
       // {
            // Implement your password verification logic here
            // Compare the stored hash with the hashed password
            // You can use libraries like BCrypt or PBKDF2 for secure password hashing

            // Example using BCrypt:
       //     return BCrypt.Net.BCrypt.Verify(password, storedHash);
       // }

        //private string HashPassword(string password)
        //{
            // Implement your password hashing logic here
            // Hash the password using a secure hashing algorithm
            // You can use libraries like BCrypt or PBKDF2 for secure password hashing

            // Example using BCrypt:
        //    return BCrypt.Net.BCrypt.HashPassword(password);
        //}
    }

}
