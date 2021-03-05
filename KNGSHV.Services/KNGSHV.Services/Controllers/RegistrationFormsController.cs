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
    public class RegistrationFormsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public readonly IRegistrationFormService _registrationFormService;

        public RegistrationFormsController(AppDbContext context, IRegistrationFormService registrationFormService)
        {
            _context = context;
            _registrationFormService = registrationFormService;
        }

        // GET: api/RegistrationForms
        [HttpGet]
        public ActionResult<IEnumerable<RegistrationFormViewModel>> GetRegistrationForms()
        {
            return _registrationFormService.GetregistrationForms();
        }

        // GET: api/RegistrationForms/5
        [HttpGet("{id}")]
        public ActionResult<RegistrationFormViewModel> GetRegistrationForm(Guid id)
        {
            return _registrationFormService.GetById(id);
        }

        // PUT: api/RegistrationForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationForm(Guid id, RegistrationFormViewModel registrationFormView)
        {
            if (id != registrationFormView.Id)
            {
                return BadRequest();
            }

            _registrationFormService.Update(registrationFormView);
            _registrationFormService.SaveChanges();

            return Ok();
        }

        // POST: api/RegistrationForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RegistrationFormViewModel> PostRegistrationForm(RegistrationFormViewModel registrationFormView)
        {
            _registrationFormService.Add(registrationFormView);
            _registrationFormService.SaveChanges();
            return Ok();
        }

        // DELETE: api/RegistrationForms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRegistrationForm(Guid id)
        {
            _registrationFormService.Delete(id);
            _registrationFormService.SaveChanges();
            return NoContent();
        }

        private bool RegistrationFormExists(Guid id)
        {
            return _context.RegistrationForms.Any(e => e.Id == id);
        }
    }
}
