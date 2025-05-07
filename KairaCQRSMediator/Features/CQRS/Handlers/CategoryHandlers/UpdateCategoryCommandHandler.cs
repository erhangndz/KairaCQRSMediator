using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository): ICommandHandler<UpdateCategoryCommand>
    {

        public async Task HandleAsync(UpdateCategoryCommand command)
        {
            var category = new Category
            {
                CategoryId = command.CategoryId,
                CategoryName = command.CategoryName,
                ImageUrl = command.ImageUrl
            };


            await _repository.UpdateAsync(category);
        }
    }
}
