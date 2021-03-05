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
    public class ClassRoomsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IClassRoomService _classRoomService;
        public ClassRoomsController(AppDbContext context, IClassRoomService classRoomService)
        {
            _context = context;
            _classRoomService = classRoomService;
        }

        // GET: api/ClassRooms
        [HttpGet]
        public ActionResult<IEnumerable<ClassRoomViewModel>> GetClassRooms()
        {
            return _classRoomService.GetClassRooms();
        }

        // GET: api/ClassRooms/5
        [HttpGet("{id}")]
        public ActionResult<ClassRoomViewModel> GetClassRoom(Guid id)
        {         

            return _classRoomService.GetById(id);
        }

        // PUT: api/ClassRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClassRoom(Guid id, ClassRoomViewModel classRoomView)
        {
            if (id != classRoomView.Id)
            {
                return BadRequest();
            }

            _classRoomService.Update(classRoomView);
            _classRoomService.SaveChanges();
            return Ok();
        }

        // POST: api/ClassRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<ClassRoom> PostClassRoom(ClassRoomViewModel classRoomView)
        {
            _classRoomService.Add(classRoomView);
            _classRoomService.SaveChanges();
            return Ok();
        }

        // DELETE: api/ClassRooms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClassRoom(Guid id)
        {
            _classRoomService.Delete(id);
            _classRoomService.SaveChanges();
            return Ok();
        }

        private bool ClassRoomExists(Guid id)
        {
            return _context.ClassRooms.Any(e => e.Id == id);
        }
    }
}
