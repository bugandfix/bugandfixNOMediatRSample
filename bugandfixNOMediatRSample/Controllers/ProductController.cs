using bugandfixNOMediatRSample.DTOs;
using bugandfixNOMediatRSample.Implementation.Commands;
using bugandfixNOMediatRSample.Implementation.Query;
using Microsoft.AspNetCore.Mvc;
using bugandfixNOMediatRSample.Implementation;


namespace bugandfixNOMediatRSample.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly Mediator _mediator;

    public ProductsController(Mediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductCommand command, CancellationToken ct)
    {
        var result = await _mediator.SendCommandAsync<CreateProductCommand, ProductDto>(command, ct);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id, CancellationToken ct)
    {
        var result = await _mediator.SendQueryAsync<GetProductByIdQuery, ProductDto?>(new(id), ct);
        if (result is null)
            return NotFound();

        return Ok(result);
    }
}