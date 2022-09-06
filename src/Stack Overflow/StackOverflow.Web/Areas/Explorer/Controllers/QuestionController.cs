using Microsoft.AspNetCore.Mvc;
using Autofac;
using StackOverflow.Web.Areas.Explorer.Models;
using StackOverflow.Web.Enums;
using Microsoft.AspNetCore.Authorization;

namespace StackOverflow.Web.Areas.Explorer.Controllers
{
    public class QuestionController : ExplorerBaseController<QuestionController>
    {
        public QuestionController(ILogger<QuestionController> logger, ILifetimeScope scope)
            : base(logger,scope)
        {

        }

        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<QuestionEditModel>();
            await model.GetUserSpecificPost();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = _scope.Resolve<QuestionCreateModel>();
            await model.GetUserInfoAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionCreateModel model)
        {

            try
            {
                model.ResolveDependency(_scope);
                await model.GetUserInfoAsync();
                if (ModelState.IsValid)
                {

                    await model.AddQuestionAsync();
                    ViewResponse("Question has been created successfully.", ResponseTypes.Success);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewResponse("Invalid Creadentials.", ResponseTypes.Warning);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Question");
                ViewResponse("Failed to create Question", ResponseTypes.Error);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = _scope.Resolve<QuestionEditModel>();
            await model.GetUserInfoAsync();
            await model.GetByIdAsyc(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuestionEditModel model)
        {

            try
            {
                model.ResolveDependency(_scope);
                await model.GetUserInfoAsync();
                if (ModelState.IsValid)
                {

                    await model.UpdateAsync();
                    ViewResponse("Question has been created updated.", ResponseTypes.Success);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewResponse("Invalid Creadentials.", ResponseTypes.Warning);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Update Question");
                ViewResponse("Failed to update Question", ResponseTypes.Error);
                return View(model);
            }
        }

        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                var model = _scope.Resolve<QuestionEditModel>();
                await model.DeleteQuestionAsync(id);
                ViewResponse("Question has been successfully deleted.", ResponseTypes.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Question");
                ViewResponse(ex.Message, ResponseTypes.Error);
            }
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult GetPosts()
        {
            var model = _scope.Resolve<QuestionEditModel>();
            model.GetTemp();
            return View();
        }


    }
}
