using Autofac;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILifetimeScope _lifetimeScope;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope lifetimeScope)
        {
            _logger = logger;
            _lifetimeScope = lifetimeScope;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PaginatedQuestion(int index)
        {
            if (index > 0)
            {
                try
                {
                    var model = _lifetimeScope.Resolve<PublicLayoutModel>();
                    var questions = await model.GetQuestions(index);
                    return Ok(questions);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return BadRequest();

        }
    }
}