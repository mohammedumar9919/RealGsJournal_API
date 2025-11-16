using RealGsJournal_API.Dtos;


namespace RealGsJournal_API.Interfaces.User
{
    public interface IAuthProvider
    {
        Task<string?> LoginAsync(LoginDto dto);
    }
}

