using KairaCQRSMediator.Dispatchers.Markers;

namespace KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands
{
    public class CreateCategoryCommand: ICommand
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
