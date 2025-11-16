using RealGsJournal_API.Interfaces.User;
using RealGsJournal_API.Dtos;
using RealGsJournal_API.Models;
using System.Security.Cryptography;
using System.Text;

namespace RealGsJournal_API.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> CreateUserAsync(CreateUserDto dto)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new Exception("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Password cannot be empty.");

            if (string.IsNullOrWhiteSpace(dto.Role))
                throw new Exception("Role is required.");

            try
            {
                // Hash password
                var passwordHash = HashPassword(dto.Password);

                return await _userRepository.CreateUserAsync(dto.Username, passwordHash, dto.Role);
            }
            catch (Exception ex)
            {
                // Re-throw clean readable messages (ex: "Username already exists.")
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new Exception("Username cannot be empty.");

            if (string.IsNullOrWhiteSpace(dto.Role))
                throw new Exception("Role is required.");

            try
            {
                return await _userRepository.UpdateUserAsync(id, dto.Username, dto.Role, dto.IsActive);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }
    }
}
