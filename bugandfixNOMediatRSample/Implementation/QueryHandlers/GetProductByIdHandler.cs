using bugandfixNOMediatRSample.Abstractions;
using bugandfixNOMediatRSample.Data;
using bugandfixNOMediatRSample.DTOs;
using bugandfixNOMediatRSample.Implementation.Query;
using bugandfixNOMediatRSample.Mappings;

namespace bugandfixNOMediatRSample.Implementation.QueryHandlers;

public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ApplicationDbContext _db;

    public GetProductByIdHandler(ApplicationDbContext db) => _db = db;

    public async Task<ProductDto?> HandleAsync(GetProductByIdQuery query, CancellationToken ct = default)
    {
        var p = await _db.Products.FindAsync(new object[] { query.Id }, ct);
        return p?.ToDto(); 
    }
}
