using Dapper;
using RealGsJournal_API.Config;
using RealGsJournal_API.Interfaces.Blog;
using RealGsJournal_API.Models;
using System.Data;

namespace RealGsJournal_API.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DapperContext _context;

        public BlogRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Blog?> CreateBlogAsync(string title, string content, int authorId, bool isPublished)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Blog>(
                "usp_Blogs_Create",
                new { Title = title, Content = content, AuthorId = authorId, IsPublished = isPublished },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Blog?> GetBlogByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Blog>(
                "usp_Blogs_GetById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<Blog>(
                "usp_Blogs_GetAll",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Blog?> UpdateBlogAsync(int id, string title, string content, int authorId, bool isPublished)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Blog>(
                "usp_Blogs_Update",
                new { Id = id, Title = title, Content = content, AuthorId = authorId, IsPublished = isPublished },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Blog?> DeleteBlogAsync(int id)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Blog>(
                "usp_Blogs_Delete",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}

