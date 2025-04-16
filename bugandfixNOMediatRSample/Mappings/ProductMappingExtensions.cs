using bugandfixNOMediatRSample.DTOs;
using bugandfixNOMediatRSample.Entities;

namespace bugandfixNOMediatRSample.Mappings;


public static class ProductMappingExtensions
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}
