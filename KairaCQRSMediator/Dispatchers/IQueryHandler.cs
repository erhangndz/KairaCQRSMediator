using KairaCQRSMediator.Dispatchers.Markers;

namespace KairaCQRSMediator.Dispatchers
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
