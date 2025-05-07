using KairaCQRSMediator.Dispatchers.Markers;

namespace KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand(int id) : ICommand
    {
        public int Id { get; set; } = id;

     
    }
}
