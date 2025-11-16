using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealGsJournal_API.Interfaces.User
{
    public interface IUserRepository
    {
        Task<RealGsJournal_API.Models.User?> CreateUserAsync(string username, string passwordHash, string role);
        Task<RealGsJournal_API.Models.User?> GetUserByIdAsync(int id);
        Task<IEnumerable<RealGsJournal_API.Models.User>> GetAllUsersAsync();
        Task<RealGsJournal_API.Models.User?> UpdateUserAsync(int id, string username, string role, bool isActive);
        Task<RealGsJournal_API.Models.User?> DeleteUserAsync(int id);
        Task<RealGsJournal_API.Models.User?> GetUserByUsernameAndPasswordHashAsync(string username, string passwordHash);
    }
}


