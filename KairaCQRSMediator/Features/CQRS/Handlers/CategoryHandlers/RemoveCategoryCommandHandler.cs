using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> _repository): ICommandHandler<RemoveCategoryCommand>
    {

        public async Task HandleAsync(RemoveCategoryCommand command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}
