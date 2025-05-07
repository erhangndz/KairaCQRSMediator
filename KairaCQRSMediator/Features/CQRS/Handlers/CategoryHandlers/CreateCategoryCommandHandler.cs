using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Dispatchers.Markers;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler(IRepository<Category> _repository) : ICommandHandler<CreateCategoryCommand>
    {

        public async Task HandleAsync(CreateCategoryCommand command)
        {
            var category = new Category
            {
                CategoryName = command.CategoryName,
                ImageUrl = command.ImageUrl
            };

            await _repository.CreateAsync(category);
        }

    }
}
