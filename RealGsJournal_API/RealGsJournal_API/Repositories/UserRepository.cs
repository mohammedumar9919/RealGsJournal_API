using Dapper;
using Microsoft.Data.SqlClient;
using RealGsJournal_API.Config;
using RealGsJournal_API.Interfaces.User;
using RealGsJournal_API.Models;
using System.Data;

namespace RealGsJournal_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(string username, string passwordHash, string role)
        {
            using var connection = _context.CreateConnection();

            try
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>(
                    "usp_Users_Create",
                    new { Username = username, PasswordHash = passwordHash, Role = role },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // UNIQUE constraint violation (duplicate username)
                throw new Exception("Username already exists.");
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<User>(
                "usp_Users_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<User>(
                "usp_Users_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<User?> UpdateUserAsync(int id, string username, string role, bool isActive)
        {
            using var connection = _context.CreateConnection();

            try
            {
                return await connection.QueryFirstOrDefaultAsync<User>(
                    "usp_Users_Update",
                    new { Id = id, Username = username, Role = role, IsActive = isActive },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new Exception("Username already exists.");
            }
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<User>(
                "usp_Users_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<User?> GetUserByUsernameAndPasswordHashAsync(string username, string passwordHash)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<User>(
                "usp_Users_GetByUsernameAndPasswordHash",
                new { Username = username, PasswordHash = passwordHash },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
