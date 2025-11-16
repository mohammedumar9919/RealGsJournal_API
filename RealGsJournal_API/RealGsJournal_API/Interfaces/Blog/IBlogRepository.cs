using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealGsJournal_API.Interfaces.Blog
{
    public interface IBlogRepository
    {
        Task<RealGsJournal_API.Models.Blog?> CreateBlogAsync(string title, string content, int authorId, bool isPublished);
        Task<RealGsJournal_API.Models.Blog?> GetBlogByIdAsync(int id);
        Task<IEnumerable<RealGsJournal_API.Models.Blog>> GetAllBlogsAsync();
        Task<RealGsJournal_API.Models.Blog?> UpdateBlogAsync(int id, string title, string content, int authorId, bool isPublished);
        Task<RealGsJournal_API.Models.Blog?> DeleteBlogAsync(int id);
    }
}


