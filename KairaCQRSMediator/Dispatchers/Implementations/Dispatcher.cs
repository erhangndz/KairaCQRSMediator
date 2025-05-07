using KairaCQRSMediator.Dispatchers.Markers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace KairaCQRSMediator.Dispatchers.Implementations
{
    public class Dispatcher(IServiceProvider _provider) : IDispatcher
    {
        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _provider.GetService<ICommandHandler<TCommand>>()
                          ?? throw new InvalidOperationException($"No Handler for {typeof(TCommand).Name}");
            await handler.HandleAsync(command);
        }

        public async Task<TResult> SendAsync<TResult>(IQuery<TResult> query)
        {
            // Fix: Specify the correct generic type arguments for IQueryHandler
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _provider.GetService(handlerType)
                ?? throw new InvalidOperationException($"No Handler for {query.GetType().Name}");

            return await handler.HandleAsync((dynamic)query);
        }
    }
}
