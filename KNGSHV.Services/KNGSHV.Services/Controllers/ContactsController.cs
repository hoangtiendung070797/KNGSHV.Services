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
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IContactService _contactService;

        public ContactsController(AppDbContext context, IContactService contactService)
        {
            _context = context;
            _contactService = contactService;
        }

        // GET: api/Contacts
        [HttpGet]
        public ActionResult<IEnumerable<ContactViewModel>> GetContacts()
        {
            return  _contactService.GetContacts();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public ActionResult<ContactViewModel> GetContact(Guid id)
        {           
             return _contactService.GetById(id);
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(Guid id, ContactViewModel contactView)
        {
            if (id != contactView.Id)
            {
                return BadRequest();
            }

            _contactService.Update(contactView);
            _contactService.SaveChanges();
            return Ok();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ContactViewModel> PostContact(ContactViewModel contactView)
        {
            _contactService.Add(contactView);
            _contactService.SaveChanges();
            return Ok();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(Guid id)
        {
            _contactService.Delete(id);
            _contactService.SaveChanges();
            return Ok();
        }

        private bool ContactExists(Guid id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
