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
    public class LectureSchedulesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILectureScheduleService _lectureScheduleService;

        public LectureSchedulesController(AppDbContext context, ILectureScheduleService lectureScheduleService)
        {
            _context = context;
            _lectureScheduleService = lectureScheduleService;
        }

        // GET: api/LectureSchedules
        [HttpGet]
        public ActionResult<IEnumerable<LectureScheduleViewModel>> GetLectureSchedules()
        {
            return _lectureScheduleService.GetLectureSchedules();
        }

        // GET: api/LectureSchedules/5
        [HttpGet("{id}")]
        public ActionResult<LectureScheduleViewModel> GetLectureSchedule(Guid id)
        {
            return _lectureScheduleService.GetById(id);
        }

        // PUT: api/LectureSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutLectureSchedule(Guid id, LectureScheduleViewModel lectureScheduleView)
        {
            if (id != lectureScheduleView.Id)
            {
                return BadRequest();
            }

            _lectureScheduleService.Update(lectureScheduleView);
            _lectureScheduleService.SaveChanges();

            return NoContent();
        }

        // POST: api/LectureSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<LectureSchedule> PostLectureSchedule(LectureScheduleViewModel lectureScheduleView)
        {
            _lectureScheduleService.Add(lectureScheduleView);
            _lectureScheduleService.SaveChanges();
            return Ok();
        }

        // DELETE: api/LectureSchedules/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLectureSchedule(Guid id)
        {
            _lectureScheduleService.Delete(id);
            _lectureScheduleService.SaveChanges();
            return Ok();
        }

        private bool LectureScheduleExists(Guid id)
        {
            return _context.LectureSchedules.Any(e => e.Id == id);
        }
    }
}
