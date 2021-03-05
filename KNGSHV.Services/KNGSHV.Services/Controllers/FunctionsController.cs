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
    public class FunctionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFunctionService _functionService;

        public FunctionsController(AppDbContext context, IFunctionService functionService)
        {
            _context = context;
            _functionService = functionService;
        }

        // GET: api/Functions
        [HttpGet]
        public ActionResult<IEnumerable<FunctionViewModel>> GetFunctions()
        {
            return _functionService.GetFunctions();
        }

        // GET: api/Functions/5
        [HttpGet("{id}")]
        public ActionResult<FunctionViewModel> GetFunction(Guid id)
        {          
            return _functionService.GetById(id);
        }

        // PUT: api/Functions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutFunction(Guid id, FunctionViewModel functionView)
        {
            if (id != functionView.Id)
            {
                return BadRequest();
            }

            _functionService.Update(functionView);
            _functionService.SaveChanges();

            return Ok();
        }

        // POST: api/Functions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<FunctionViewModel> PostFunction(FunctionViewModel functionView)
        {
            _functionService.Add(functionView);

            _functionService.SaveChanges();

            return Ok();
        }

        // DELETE: api/Functions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFunction(Guid id)
        {
            _functionService.Delete(id);
            return NoContent();
        }

        private bool FunctionExists(Guid id)
        {
            return _context.Functions.Any(e => e.Id == id);
        }
    }
}
