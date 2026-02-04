
using backend_api.Domain.Entities;

namespace backend_api.Application.Categories.Queries.GetCategories;

public class CategoryDto
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
