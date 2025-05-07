using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery,GetCategoryByIdQueryResult>
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> HandleAsync(GetCategoryByIdQuery query)
        {
            var category = await _repository.GetByIdAsync(query.Id);

            return new GetCategoryByIdQueryResult
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                ImageUrl = category.ImageUrl
               
            };


        }

    }
}
