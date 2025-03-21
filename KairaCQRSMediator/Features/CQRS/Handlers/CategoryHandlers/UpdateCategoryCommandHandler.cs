using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository)
    {

        public async Task Handle(UpdateCategoryCommand command)
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
