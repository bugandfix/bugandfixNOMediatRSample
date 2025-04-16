using bugandfixNOMediatRSample.Abstractions;
using bugandfixNOMediatRSample.DTOs;

namespace bugandfixNOMediatRSample.Implementation.Commands;

public record CreateProductCommand(string Name, decimal Price) : ICommand<ProductDto>;