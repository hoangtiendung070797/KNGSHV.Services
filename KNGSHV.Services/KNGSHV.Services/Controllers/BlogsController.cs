using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KNGSHV.Data.EF;
using KNGSHV.Data.Entities;
using KNGSHV.Application.Interfaces;
using KNGSHV.Application.ViewModels;

namespace KNGSHV.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;

        public BlogsController(AppDbContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        // GET: api/Blogs
        [HttpGet]
        public ActionResult<IEnumerable<BlogViewModel>> GetBlogs()
        {
            return _blogService.GetBlogs();
        }

        // GET: api/BlogsDetail
        [HttpGet]
        [Route("BlogsDetail")]
        public ActionResult<IEnumerable<BlogViewModel>> GetBlogsDetail ()
        {
            return _blogService.GetBlogsDetail();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public ActionResult<BlogViewModel> GetBlog(Guid id)
        {
            return _blogService.GetById(id);
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBlog(Guid id, BlogViewModel blogView)
        {
            if (id != blogView.Id)
            {
                return BadRequest();
            }

            _blogService.Update(blogView);
            _blogService.SaveChanges();

            return Ok();
        }

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Blog> PostBlog(BlogViewModel blogView)
        {
            _blogService.Add(blogView);
            _blogService.SaveChanges();
            return Ok();
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(Guid id)
        {
            _blogService.Delete(id);
            _blogService.SaveChanges();
            return Ok();
        }

        private bool BlogExists(Guid id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
