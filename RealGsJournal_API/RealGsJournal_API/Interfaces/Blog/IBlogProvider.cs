using RealGsJournal_API.Dtos;

namespace RealGsJournal_API.Interfaces.Blog
{
    public interface IBlogProvider
    {
        Task<RealGsJournal_API.Models.Blog?> CreateBlogAsync(BlogCreateDto dto);
        Task<RealGsJournal_API.Models.Blog?> GetBlogByIdAsync(int id);
        Task<IEnumerable<RealGsJournal_API.Models.Blog>> GetAllBlogsAsync();
        Task<RealGsJournal_API.Models.Blog?> UpdateBlogAsync(int id, BlogUpdateDto dto);
        Task<RealGsJournal_API.Models.Blog?> DeleteBlogAsync(int id);
    }
}


