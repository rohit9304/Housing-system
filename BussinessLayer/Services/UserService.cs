using Housing_system.BussinessLayer.DTO;
using Housing_system.DataLayer.Interfaces;
using Housing_system.DataLayer.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
            try
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

                _userRepository.Register(registrationDto.Username, registrationDto.Password, registrationDto.Email);
                _userRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new ApplicationException("An error occurred while registering the user.", ex);
            }
        }

        public string AuthenticateUser(UserLoginDto loginDto)
        {
            try
            {
                var user = _userRepository.Authenticate(loginDto.Username, loginDto.Password);

                // Check if user exists and password is correct
                if (user == null)
                {
                    throw new ApplicationException("Invalid username or password.");
                }

                // Generate JWT token
                var token = GenerateJwtToken(user);

                return token;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new ApplicationException("An error occurred while authenticating the user.", ex);
            }
        }

        private string GenerateJwtToken(User user)
        {
            try
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
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new ApplicationException("An error occurred while generating the JWT token.", ex);
            }
        }
    }
}
