using KairaCQRSMediator.Dispatchers.Markers;

namespace KairaCQRSMediator.Dispatchers
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {

        Task HandleAsync(TCommand command);
    }
}
