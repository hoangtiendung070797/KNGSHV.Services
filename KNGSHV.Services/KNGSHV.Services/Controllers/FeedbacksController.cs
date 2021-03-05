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
    public class FeedbacksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(AppDbContext context, IFeedbackService feedbackService)
        {
            _context = context;
            _feedbackService = feedbackService;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public ActionResult<IEnumerable<FeedbackViewModel>> GetFeedbacks()
        {
            return _feedbackService.GetFeedbacks();
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public ActionResult<FeedbackViewModel> GetFeedback(Guid id)
        {
           
            return _feedbackService.GetById(id);
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(Guid id, FeedbackViewModel feedbackView)
        {
            if (id != feedbackView.Id)
            {
                return BadRequest();
            }

            _feedbackService.Update(feedbackView);
            _feedbackService.SaveChanges();
            return Ok();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<FeedbackViewModel> PostFeedback(FeedbackViewModel feedbackView)
        {
            _feedbackService.Add(feedbackView);
            _feedbackService.SaveChanges();

            return Ok();
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFeedback(Guid id)
        {
            _feedbackService.Delete(id);
            _feedbackService.SaveChanges();

            return Ok();
        }

        private bool FeedbackExists(Guid id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
