using bugandfixNOMediatRSample.Abstractions;
using bugandfixNOMediatRSample.Data;
using bugandfixNOMediatRSample.DTOs;
using bugandfixNOMediatRSample.Entities;
using bugandfixNOMediatRSample.Implementation.Commands;
using bugandfixNOMediatRSample.Mappings;

namespace bugandfixNOMediatRSample.Implementation.CommandHandlers;


public class CreateProductHandler : ICommandHandler<CreateProductCommand, ProductDto>
{
    private readonly ApplicationDbContext _db;

    public CreateProductHandler(ApplicationDbContext db) => _db = db;

    public async Task<ProductDto> HandleAsync(CreateProductCommand command, CancellationToken ct = default)
    {
        var product = new Product { Name = command.Name, Price = command.Price };
        _db.Products.Add(product);
        await _db.SaveChangesAsync(ct);
        
        return product.ToDto();
    }
}
