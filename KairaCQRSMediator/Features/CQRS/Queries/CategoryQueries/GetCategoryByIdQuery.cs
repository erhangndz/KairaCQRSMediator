using KairaCQRSMediator.Dispatchers.Markers;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;

namespace KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery: IQuery<GetCategoryByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
