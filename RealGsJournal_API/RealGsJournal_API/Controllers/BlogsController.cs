using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealGsJournal_API.Dtos;
using RealGsJournal_API.Interfaces.Blog;

namespace RealGsJournal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogProvider _blogProvider;

        public BlogsController(IBlogProvider blogProvider)
        {
            _blogProvider = blogProvider;
        }

        // ADMIN + VIEWER
        [HttpGet]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogProvider.GetAllBlogsAsync();
            return Ok(blogs);
        }

        // ADMIN + VIEWER
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogProvider.GetBlogByIdAsync(id);
            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        // ADMIN ONLY
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] BlogCreateDto dto)
        {
            var blog = await _blogProvider.CreateBlogAsync(dto);
            return Ok(blog);
        }

        // ADMIN ONLY
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] BlogUpdateDto dto)
        {
            var updated = await _blogProvider.UpdateBlogAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // ADMIN ONLY
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _blogProvider.DeleteBlogAsync(id);
            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
    }
}

