using RealGsJournal_API.Dtos;
using RealGsJournal_API.Interfaces.Blog;
using RealGsJournal_API.Models;

namespace RealGsJournal_API.Providers
{
    public class BlogProvider : IBlogProvider
    {
        private readonly IBlogRepository _blogRepository;

        public BlogProvider(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog?> CreateBlogAsync(BlogCreateDto dto)
        {
            return await _blogRepository.CreateBlogAsync(
                dto.Title,
                dto.Content,
                dto.AuthorId,
                dto.IsPublished
            );
        }

        public async Task<Blog?> GetBlogByIdAsync(int id)
        {
            return await _blogRepository.GetBlogByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _blogRepository.GetAllBlogsAsync();
        }

        public async Task<Blog?> UpdateBlogAsync(int id, BlogUpdateDto dto)
        {
            return await _blogRepository.UpdateBlogAsync(
                id,
                dto.Title,
                dto.Content,
                dto.AuthorId,
                dto.IsPublished
            );
        }

        public async Task<Blog?> DeleteBlogAsync(int id)
        {
            return await _blogRepository.DeleteBlogAsync(id);
        }
    }
}

