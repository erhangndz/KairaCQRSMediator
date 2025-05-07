using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Dispatchers;
using KairaCQRSMediator.Features.CQRS.Queries.CategoryQueries;
using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler(IRepository<Category> _categoryRepository) : IQueryHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        public async Task<List<GetCategoryQueryResult>> HandleAsync(GetCategoryQuery query)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(category => new GetCategoryQueryResult
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                ImageUrl = category.ImageUrl,
                Products = (IList<GetProductsQueryResult>)category.Products
            }).ToList();
        }
    }
}
