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
    public class SubjectsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ISubjectService _subjectService;

        public SubjectsController(AppDbContext context, ISubjectService subjectService)
        {
            _context = context;
            _subjectService = subjectService;
        }

        // GET: api/Subjects
        [HttpGet]
        public ActionResult<IEnumerable<SubjectViewModel>> GetSubjects()
        {
            return _subjectService.GetSubjects();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public ActionResult<SubjectViewModel> GetSubject(Guid id)
        {   
            return _subjectService.GetById(id);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSubject(Guid id, SubjectViewModel subjectView)
        {
            if (id != subjectView.Id)
            {
                return BadRequest();
            }

            _subjectService.Update(subjectView);
            _subjectService.SaveChanges();
            return NoContent();
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<SubjectViewModel> PostSubject(SubjectViewModel subjectView)
        {
            _subjectService.Add(subjectView);
            _subjectService.SaveChanges();
            return Ok();
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(Guid id)
        {
            _subjectService.Delete(id);
            _subjectService.SaveChanges();

            return NoContent();
        }

        private bool SubjectExists(Guid id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
