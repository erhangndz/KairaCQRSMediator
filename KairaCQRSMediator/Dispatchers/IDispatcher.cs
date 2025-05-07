using KairaCQRSMediator.Dispatchers.Markers;

namespace KairaCQRSMediator.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        Task<TResult> SendAsync<TResult>(IQuery<TResult> query);
    }
}
