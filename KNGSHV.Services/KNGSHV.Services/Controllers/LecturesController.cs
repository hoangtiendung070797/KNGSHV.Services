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
    public class LecturesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILectureService _lectureService;

        public LecturesController(AppDbContext context, ILectureService lectureService)
        {
            _context = context;
            _lectureService = lectureService;
        }

        // GET: api/Lectures
        [HttpGet]
        public ActionResult<IEnumerable<LectureViewModel>> GetLectures()
        {
            return _lectureService.GetLectures();
        }

        // GET: api/Lectures/5
        [HttpGet("{id}")]
        public ActionResult<LectureViewModel> GetLecture(Guid id)
        {
            return _lectureService.GetById(id);

        }

        // PUT: api/Lectures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecture(Guid id, LectureViewModel lectureView)
        {
            if (id != lectureView.Id)
            {
                return BadRequest();
            }

            _lectureService.Update(lectureView);
            _lectureService.SaveChanges();
            return Ok();
        }

        // POST: api/Lectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Lecture> PostLecture(LectureViewModel lectureView)
        {
            _lectureService.Add(lectureView);
            _lectureService.SaveChanges();
            return Ok();
        }

        // DELETE: api/Lectures/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLecture(Guid id)
        {
            try
            {
                _lectureService.Delete(id);
                _lectureService.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private bool LectureExists(Guid id)
        {
            return _context.Lectures.Any(e => e.Id == id);
        }
    }
}
