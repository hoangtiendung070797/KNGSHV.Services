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
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICourseService _courseService;

        public CoursesController(AppDbContext context, ICourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public ActionResult<IEnumerable<CourseViewModel>> GetCourses()
        {
            return _courseService.GetCourse();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public ActionResult<CourseViewModel> GetCourse(Guid id)
        {

            return _courseService.GetById(id);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCourse(Guid id, CourseViewModel courseView)
        {
            if (id != courseView.Id)
            {
                return BadRequest();
            }

            _courseService.Update(courseView);
            _courseService.SaveChanges();

            return Ok();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Course> PostCourse(CourseViewModel courseView)
        {
            _courseService.Add(courseView);
            _courseService.SaveChanges();
            return Ok();
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            _courseService.Delete(id);
            _courseService.SaveChanges();
            return Ok();
        }

        private bool CourseExists(Guid id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
