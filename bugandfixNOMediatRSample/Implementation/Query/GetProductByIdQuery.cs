using bugandfixNOMediatRSample.Abstractions;
using bugandfixNOMediatRSample.DTOs;

namespace bugandfixNOMediatRSample.Implementation.Query;


public record GetProductByIdQuery(Guid Id) : IQuery<ProductDto?>;
