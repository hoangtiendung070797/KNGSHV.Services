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
using KNGSHV.Application.ViewModels.ReponseApi;

namespace KNGSHV.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILearnerService _learnerService;

        public LearnersController(AppDbContext context, ILearnerService learnerService)
        {
            _context = context;
            _learnerService = learnerService;
        }

        // GET: api/Learners
        [HttpGet]
        public ActionResult<IEnumerable<LearnerViewModel>> GetLearners()
        {
            return _learnerService.GetLearners();
        }

        // GET: api/Learners/5
        [HttpGet("{id}")]
        public ActionResult<LearnerViewModel> GetLearner(Guid id)
        {
           
            return _learnerService.GetById(id);
        }

        // PUT: api/Learners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutLearner(Guid id, LearnerViewModel learnerView )
        {
            if (id != learnerView.Id)
            {
                return BadRequest();
            }

            _learnerService.Update(learnerView);
            _learnerService.SaveChanges();

            return Ok();
        }

        // POST: api/Learners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<LearnerViewModel> PostLearner(LearnerViewModel learnerView)
        {
            _learnerService.Add(learnerView);
            _learnerService.SaveChanges();
            return Ok();
        }

        // DELETE: api/Learners/5
        [HttpDelete("{id}")]
        public object DeleteLearner(Guid id)
        {
            try
            {
                _learnerService.Delete(id);
                _learnerService.SaveChanges();
                return new ResponseApi<string>("Xóa thành công!", Application.ViewModels.ReponseApi.StatusCode.Success);
            }
            catch (Exception)
            {

                return new ResponseApi<string>("Xóa thành công!", Application.ViewModels.ReponseApi.StatusCode.Success);
            }


        }

        private bool LearnerExists(Guid id)
        {
            return _context.Learners.Any(e => e.Id == id);
        }
    }
}
