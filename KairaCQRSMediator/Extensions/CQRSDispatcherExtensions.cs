using System.Reflection;
using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Dispatchers.Implementations;

namespace KairaCQRSMediator.Extensions
{
    public static class CQRSDispatcherExtensions
    {

        public static IServiceCollection AddCqrsDispatcher(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();

            return services;
        }


        public static IServiceCollection AutoRegisterCqrsHandlers<TApplication>(this IServiceCollection services)
        {
            var assembly = typeof(TApplication).Assembly;

            RegisterCommandHandlers(services, assembly);

            RegisterQueryHandlers(services, assembly);

            return services;
        }

        private static void RegisterCommandHandlers(IServiceCollection services, Assembly assembly)
        {
            var commandHandlerType = typeof(ICommandHandler<>);

            var commandHandlerTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandHandlerType));

            foreach (var handlerType in commandHandlerTypes)
            {
                var handlerInterfaces = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandHandlerType);

                foreach (var handlerInterface in handlerInterfaces)
                {
                    services.AddScoped(handlerInterface, handlerType);
                }
            }
        }

        private static void RegisterQueryHandlers(IServiceCollection services, Assembly assembly)
        {
            var queryHandlerType = typeof(IQueryHandler<,>);

            var queryHandlerTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == queryHandlerType));

            foreach (var handlerType in queryHandlerTypes)
            {
                
                var handlerInterfaces = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == queryHandlerType);

                foreach (var handlerInterface in handlerInterfaces)
                {
                    
                    services.AddScoped(handlerInterface, handlerType);
                }
            }
        }




    }


    
}
