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

        public async Task<IActionResult> AddAnswer(string description, int questionId, int totalVote)
        {
            var model = _scope.Resolve<AnswerCreateModel>();
            await model.AnswerAsync(description, questionId, totalVote);
            return Ok();
        }
    }
}
