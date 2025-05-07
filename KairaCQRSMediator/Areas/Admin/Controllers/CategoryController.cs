using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers;
using KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(IDispatcher _dispatcher) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values =
                await _dispatcher.SendAsync(new GetCategoryQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _dispatcher.SendAsync(new GetCategoryByIdQuery(id));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _dispatcher.SendAsync(command);
            return RedirectToAction("Index");
        }


        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _dispatcher.SendAsync(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _dispatcher.SendAsync(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
    }
}
