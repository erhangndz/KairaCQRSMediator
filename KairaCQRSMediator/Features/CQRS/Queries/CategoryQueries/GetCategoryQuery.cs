using KairaCQRSMediator.Dispatchers.Markers;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;

namespace KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryQuery: IQuery<List<GetCategoryQueryResult>>
    {
    }
}
