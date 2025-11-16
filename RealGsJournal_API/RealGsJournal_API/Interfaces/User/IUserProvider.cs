using RealGsJournal_API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealGsJournal_API.Interfaces.User
{
    public interface IUserProvider
    {
        Task<RealGsJournal_API.Models.User?> CreateUserAsync(CreateUserDto dto);
        Task<RealGsJournal_API.Models.User?> GetUserByIdAsync(int id);
        Task<IEnumerable<RealGsJournal_API.Models.User>> GetAllUsersAsync();
        Task<RealGsJournal_API.Models.User?> UpdateUserAsync(int id, UpdateUserDto dto);
        Task<RealGsJournal_API.Models.User?> DeleteUserAsync(int id);
    }
}


