using Microsoft.AspNetCore.Mvc;
using Autofac;
using StackOverflow.Web.Areas.Explorer.Models;
using StackOverflow.Web.Enums;
using Microsoft.AspNetCore.Authorization;

namespace StackOverflow.Web.Areas.Explorer.Controllers
{
    public class AnswerController : ExplorerBaseController<AnswerController>
    {
        public AnswerController(ILogger<AnswerController> logger, ILifetimeScope scope)
            : base(logger, scope)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> AddAnswer(string answerText, int quesId)
        {
            var model = _scope.Resolve<AnswerCreateModel>();
            await model.AnswerAsync(answerText, quesId);
            return Ok(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> AddComment(string commentVal, int answerId)
        {
            var model = _scope.Resolve<AnswerCreateModel>();
            
            await model.CommentAsync(commentVal,answerId);
            return Ok(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> AddQuestionVote(int quesId)
        {
            var model = _scope.Resolve<AnswerCreateModel>();

            await model.GetQuestionVote(quesId);
            return Ok(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> AddAnsVote(int answerId)
        {
            if (answerId == 0)
                return BadRequest(answerId);

            var model = _scope.Resolve<AnswerCreateModel>();

             await model.GetAnsVote(answerId);
            return Ok(model);
        }
    }
}
