using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Web.Controllers;

namespace StackOverflow.Web.Areas.Explorer.Controllers
{
    [Area("Explorer")]
    [Authorize(Roles = "User")]
    public class ExplorerBaseController<T> : BaseController<T>
        where T : Controller
    {
        public ExplorerBaseController(ILogger<T> logger, ILifetimeScope scope)
            : base(logger,scope)
        {
        }
    }
}
