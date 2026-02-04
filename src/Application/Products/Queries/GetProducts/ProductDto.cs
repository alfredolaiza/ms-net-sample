using backend_api.Domain.Entities;

namespace backend_api.Application.Products.Queries.GetProducts;

public class ProductDto
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public decimal Price { get; init; }

    public int Stock { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
