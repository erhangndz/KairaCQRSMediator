using KairaCQRSMediator.Dispatchers.Markers;

namespace KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : ICommand
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
