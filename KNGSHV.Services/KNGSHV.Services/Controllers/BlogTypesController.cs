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
    public class BlogTypesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBlogTypeService _blogTypeService;

        public BlogTypesController(AppDbContext context, IBlogTypeService blogTypeService)
        {
            _context = context;
            _blogTypeService = blogTypeService;
        }

        // GET: api/BlogTypes
        [HttpGet]
        public ActionResult<IEnumerable<BlogTypeViewModel>> GetBlogTypes()
        {
             return _blogTypeService.GetAccounts();
        }

        // GET: api/BlogTypes/5
        [HttpGet("{id}")]
        public  ActionResult<BlogTypeViewModel> GetBlogType(Guid id)
        {            
             return _blogTypeService.GetById(id);
        }

        // PUT: api/BlogTypes/5 
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutBlogType(Guid id, BlogTypeViewModel blogTypeView)
        {
            if (id != blogTypeView.Id)
            {
                return BadRequest();
            }
            _blogTypeService.Update(blogTypeView);
            _blogTypeService.SaveChanges();           
            return NoContent();
        }

        // POST: api/BlogTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<BlogTypeViewModel> PostBlogType(BlogTypeViewModel blogTypeView)
        {
            _blogTypeService.Add(blogTypeView);
            _blogTypeService.SaveChanges();
            return NoContent();
        }

        // DELETE: api/BlogTypes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogType(Guid id)
        {

            _blogTypeService.Delete(id);
            _blogTypeService.SaveChanges();
            return NoContent();
        }

        private bool BlogTypeExists(Guid id)
        {
            return _context.BlogTypes.Any(e => e.Id == id);
        }
    }
}
